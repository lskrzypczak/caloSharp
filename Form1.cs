using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using System.Diagnostics;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace caloSharp
{
    public partial class Form1 : Form
    {
        private string hexContent = string.Empty;
        private byte[] binData = new byte[0];
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Thread audioThread;
        private string filePath = string.Empty;

        private string hexConstructRecord(byte recordType, ushort address, byte[] data)
        {
            var recordStr = string.Empty;
            byte numBytes;
            List<byte> record = new List<byte>();

            recordType = (byte)(recordType & (byte)0xFF);
            numBytes = (byte)(data.Length & 0xFF);


            record.Add(numBytes);
            record.Add((byte)(address >> 8));
            record.Add((byte)address);

            record.Add(recordType);
            foreach (byte b in data)
                record.Add(b);


            byte checksum = 0;
            foreach (byte b in record)
                checksum += b;
            checksum &= 0xFF;

            // Two's complement
            checksum = (byte)(~checksum + 1);
            checksum &= 0xFF;


            record.Add(checksum);

            recordStr = ":";
            foreach (byte b in record)
                recordStr += string.Format("{0:X2}", b);
            recordStr += "\n";

            return recordStr;
        }

        private string bin2hex(ushort address, byte[] bin)
        {
            var hex = string.Empty;
            List<byte> data = new List<byte>();
            ushort addr = address;

            int numBytes = 1;

            foreach (byte b in bin)
            {
                data.Add(b);
                if (numBytes >= 16)
                {
                    hex += hexConstructRecord(0x00, addr, data.ToArray());
                    data.Clear();
                    numBytes = 0;
                    addr += 16;
                }
                numBytes++;
            }

            hex += hexConstructRecord(0x01, 0x0000, new byte[0]);


            return hex;
        }

        private byte[] OpenReadBinary()
        {
            byte[] fileContent = new byte[0];

            openFileBinary.InitialDirectory = ".";
            openFileBinary.Filter = "bin files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileBinary.FilterIndex = 1;
            openFileBinary.RestoreDirectory = true;

            if ( this.openFileBinary.ShowDialog() == DialogResult.OK )
            {
                //Get the path of specified file
                filePath = openFileBinary.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileBinary.OpenFile();

                using (BinaryReader reader = new BinaryReader(fileStream))
                {
                    fileContent = reader.ReadBytes((int)fileStream.Length);
                }

                fileStream.Close();
            }

            return fileContent;
        }

        private string OpenReadHex()
        {
            var fileContent = string.Empty;

            openFileHex.InitialDirectory = ".";
            openFileHex.Filter = "hex files (*.hex)|*.hex|All files (*.*)|*.*";
            openFileHex.FilterIndex = 1;
            openFileHex.RestoreDirectory = true;

            if (this.openFileHex.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = openFileHex.FileName;

                //Read the contents of the file into a stream
                var fileStream = openFileHex.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                fileStream.Close();
            }

            return fileContent;
        }

        private void SaveHex(string hex)
        {
            var filePath = string.Empty;

            saveFileHex.InitialDirectory = ".";
            saveFileHex.Filter = "hex files (*.hex)|*.hex|All files (*.*)|*.*";
            saveFileHex.FilterIndex = 1;
            saveFileHex.RestoreDirectory = true;

            if (this.saveFileHex.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileHex.FileName;
                var fileStream = saveFileHex.OpenFile();

                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    writer.Write(hex);
                }

                fileStream.Close();
            }
        }

        private void OnPlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs args)
        {
            if ((audioThread != null) && (audioThread.IsAlive))
                audioThread.Abort();

            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;

            bPlayAudio.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();

            string[] serialPortList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in serialPortList) {
                this.cBPorts.Items.Add(s);
            }
            if (cBPorts.Items.Count > 0)
                cBPorts.SelectedIndex = 0;

            bSend.Enabled = false;

            for (int n = -1; n < WaveOut.DeviceCount; n++)
            {
                var caps = WaveOut.GetCapabilities(n);
                //Console.WriteLine($"{n}: {caps.ProductName}");
                cBAudioDevices.Items.Add(caps.ProductName);
            }
            if (cBAudioDevices.Items.Count > 0)
                cBAudioDevices.SelectedIndex = 0;

            toolStripStatusLabel1.Text = "Ready";
            bSaveHex.Enabled = false;
            saveIHEXToolStripMenuItem.Enabled = false;

            cBAudioDevices.Visible = false;
            bPlayAudio.Visible = false;

            bRefreshBinary.Enabled = false;
            bRefreshHex.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openBinaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // enable address box
            tBAddress.Enabled = true;
            ushort address = 0x0000;

            try
            {
                address = Convert.ToUInt16(tBAddress.Text, 16);
            }
            catch
            {
                MessageBox.Show("Incorrect address !");
            }

            binData = OpenReadBinary();
            hexContent = bin2hex(address, binData);
            tBHexView.Clear();
            tBHexView.Text = hexContent;
            bSend.Enabled = true;

            bSaveHex.Enabled = true;
            saveIHEXToolStripMenuItem.Enabled = true;

            bRefreshBinary.Enabled = true;
            bRefreshHex.Enabled = false;
        }

        private void openIHEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hexContent = OpenReadHex();

            //disable addrss textbox as iHEX defines load address
            tBAddress.Enabled = false;
            bSend.Enabled = true;

            tBHexView.Clear();
            tBHexView.Text = hexContent;
            bRefreshBinary.Enabled = false;
            bRefreshHex.Enabled = true;

        }

        private void saveIHEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveHex(hexContent);
        }

        private void bOpenBinary_Click(object sender, EventArgs e)
        {
            openBinaryToolStripMenuItem_Click(sender, e);
        }

        private void bOpenHex_Click(object sender, EventArgs e)
        {
            openIHEXToolStripMenuItem_Click(sender, e);
        }

        private void bSaveHex_Click(object sender, EventArgs e)
        {
            saveIHEXToolStripMenuItem_Click(sender, e);
        }

        private void bRescanPorts_Click(object sender, EventArgs e)
        {
            cBPorts.Items.Clear();

            string[] serialPortList = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in serialPortList)
            {
                this.cBPorts.Items.Add(s);
            }
            if (cBPorts.Items.Count > 0)
                cBPorts.SelectedIndex = 0;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        char getResponse(System.IO.Ports.SerialPort serial)
        {
            char ch;

            do
            {
                try
                {
                    ch = (char)serial.ReadByte();
                    Debug.WriteLine("d: "+ string.Format("0x{0:X2}", (byte)ch));
                }
                catch(Exception e)
                {
                    Debug.WriteLine("timeout: " + e.Message);
                    return '?';
                }
                if ((ch == '.') || (ch == '-') || (ch == '!') || (ch == '\n'))
                {
                    return ch;
                }
            } while (serial.BytesToRead > 0);
            return '?';
        }
        private void bSend_Click(object sender, EventArgs e)
        {
            System.IO.Ports.SerialPort _serial = serialPort1;
            string[] lines = hexContent.Split('\n');
            toolStripProgressBar1.Maximum = lines.Length;
            toolStripProgressBar1.Value = 0;

            _serial.BaudRate = 19200;
            _serial.Parity = System.IO.Ports.Parity.None;
            _serial.StopBits = System.IO.Ports.StopBits.One;
            _serial.DataBits = 8;
            _serial.ReadTimeout = 200;      //200ms timeout
            _serial.PortName = cBPorts.SelectedItem.ToString();

            toolStripStatusLabel1.Text = "Opening port " + _serial.PortName;

            try
            {
                _serial.Open();
            }
            catch
            {
                MessageBox.Show("Error opening serial port !");
                return;
            }

            toolStripStatusLabel1.Text = "Sending...";

            foreach (string s in lines)
            {
                toolStripStatusLabel1.Text = s;
                Debug.WriteLine(s);
                byte[] array = Encoding.ASCII.GetBytes(s + '\n');
                _serial.Write(array, 0, array.Length);

                char resp = getResponse(_serial);
                if (resp == '\n')
                    resp = getResponse(_serial);
                switch (resp)
                {
                    case '.':
                        toolStripProgressBar1.Value++;
                        continue;

                    case '-':
                        toolStripStatusLabel1.Text = "Done !";
                        _serial.Close();
                        return;

                    case '!':
                        toolStripStatusLabel1.Text = "88,err,load error (CA80 reported) on " + s;
                        _serial.Close();
                        return;

                    case '?':
                        toolStripStatusLabel1.Text = "77,err,CA80 link failure";
                        _serial.Close();
                        return;
                }
                System.Threading.Thread.Sleep(100);
            }
            _serial.Close();
        }

        private void tBAddress_TextChanged(object sender, EventArgs e)
        {
            ushort address = 0x0000;

            try
            {
                address = Convert.ToUInt16(tBAddress.Text, 16);
            }
            catch
            {
                MessageBox.Show("Incorrect address !");
            }

            hexContent = bin2hex(address, binData);
            tBHexView.Clear();
            tBHexView.Text = hexContent;
        }

        private void bPlayAudio_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent() { DeviceNumber = cBAudioDevices.SelectedIndex };
                outputDevice.PlaybackStopped += OnPlaybackStopped;
                outputDevice.Volume = 0.7f;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@".\calo4000.55.prg.wav");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
            bPlayAudio.Enabled = false;

            toolStripProgressBar1.Maximum = (int)(audioFile.Length * 1000.0 / this.outputDevice.OutputWaveFormat.BitsPerSample / this.outputDevice.OutputWaveFormat.Channels * 8.0 / this.outputDevice.OutputWaveFormat.SampleRate);
            toolStripStatusLabel1.Text = toolStripProgressBar1.Maximum.ToString();

            toolStripStatusLabel1.Text = audioFile.FileName;

            // When starting to play, start a new thread to get progress
            this.audioThread = new System.Threading.Thread(new System.Threading.ThreadStart(OnPlaying));
            this.audioThread.Start();
        }

        private void OnPlaying()
        {

                while (true)
                {
                    if (this.outputDevice.PlaybackState == PlaybackState.Playing)
                    {
                        double ms = this.outputDevice.GetPosition() * 1000.0 / this.outputDevice.OutputWaveFormat.BitsPerSample / this.outputDevice.OutputWaveFormat.Channels * 8.0 / this.outputDevice.OutputWaveFormat.SampleRate;

                        // Console.WriteLine("Milliseconds Played: " + ms);
                        Invoke((MethodInvoker)delegate
                        {
                            //update the progress bar here
                            if ((int)ms < toolStripProgressBar1.Maximum)
                                toolStripProgressBar1.Value = (int)ms;
                        });
                    }

                    System.Threading.Thread.Sleep(100);
                }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((audioThread != null) && (audioThread.IsAlive))
                audioThread.Abort();
        }

        private void bRefreshBinary_Click(object sender, EventArgs e)
        {
            //Read the contents of the file into a stream
            var fileStream = openFileBinary.OpenFile();

            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                binData = reader.ReadBytes((int)fileStream.Length);
            }

            fileStream.Close();

            // enable address box
            tBAddress.Enabled = true;
            ushort address = 0x0000;

            try
            {
                address = Convert.ToUInt16(tBAddress.Text, 16);
            }
            catch
            {
                MessageBox.Show("Incorrect address !");
            }

            hexContent = bin2hex(address, binData);
            tBHexView.Clear();
            tBHexView.Text = hexContent;
            bSend.Enabled = true;

            bSaveHex.Enabled = true;
            saveIHEXToolStripMenuItem.Enabled = true;

            bRefreshBinary.Enabled = true;
            bRefreshHex.Enabled = false;
        }

        private void bRefreshHex_Click(object sender, EventArgs e)
        {
            //Read the contents of the file into a stream
            var fileStream = openFileHex.OpenFile();

            using (StreamReader reader = new StreamReader(fileStream))
            {
                hexContent = reader.ReadToEnd();
            }

            fileStream.Close();

            //disable addrss textbox as iHEX defines load address
            tBAddress.Enabled = false;
            bSend.Enabled = true;

            tBHexView.Clear();
            tBHexView.Text = hexContent;
            bRefreshBinary.Enabled = false;
            bRefreshHex.Enabled = true;
        }
    }
}
