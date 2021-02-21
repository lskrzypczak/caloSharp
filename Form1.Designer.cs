namespace caloSharp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBinaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openIHEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveIHEXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileBinary = new System.Windows.Forms.OpenFileDialog();
            this.openFileHex = new System.Windows.Forms.OpenFileDialog();
            this.saveFileHex = new System.Windows.Forms.SaveFileDialog();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.gbCA80 = new System.Windows.Forms.GroupBox();
            this.bPlayAudio = new System.Windows.Forms.Button();
            this.cBAudioDevices = new System.Windows.Forms.ComboBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bSaveHex = new System.Windows.Forms.Button();
            this.bOpenHex = new System.Windows.Forms.Button();
            this.bOpenBinary = new System.Windows.Forms.Button();
            this.bSend = new System.Windows.Forms.Button();
            this.bRescanPorts = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cBPorts = new System.Windows.Forms.ComboBox();
            this.tBAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gBHexView = new System.Windows.Forms.GroupBox();
            this.tBHexView = new System.Windows.Forms.TextBox();
            this.bRefreshBinary = new System.Windows.Forms.Button();
            this.bRefreshHex = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.gbCA80.SuspendLayout();
            this.gBHexView.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(553, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(553, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBinaryToolStripMenuItem,
            this.openIHEXToolStripMenuItem,
            this.saveIHEXToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openBinaryToolStripMenuItem
            // 
            this.openBinaryToolStripMenuItem.Name = "openBinaryToolStripMenuItem";
            this.openBinaryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openBinaryToolStripMenuItem.Text = "Open binary...";
            this.openBinaryToolStripMenuItem.Click += new System.EventHandler(this.openBinaryToolStripMenuItem_Click);
            // 
            // openIHEXToolStripMenuItem
            // 
            this.openIHEXToolStripMenuItem.Name = "openIHEXToolStripMenuItem";
            this.openIHEXToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openIHEXToolStripMenuItem.Text = "Open iHEX...";
            this.openIHEXToolStripMenuItem.Click += new System.EventHandler(this.openIHEXToolStripMenuItem_Click);
            // 
            // saveIHEXToolStripMenuItem
            // 
            this.saveIHEXToolStripMenuItem.Name = "saveIHEXToolStripMenuItem";
            this.saveIHEXToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.saveIHEXToolStripMenuItem.Text = "Save iHEX...";
            this.saveIHEXToolStripMenuItem.Click += new System.EventHandler(this.saveIHEXToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // openFileBinary
            // 
            this.openFileBinary.FileName = "openFileDialog1";
            // 
            // openFileHex
            // 
            this.openFileHex.FileName = "openFileDialog2";
            // 
            // gbCA80
            // 
            this.gbCA80.Controls.Add(this.bRefreshHex);
            this.gbCA80.Controls.Add(this.bRefreshBinary);
            this.gbCA80.Controls.Add(this.bPlayAudio);
            this.gbCA80.Controls.Add(this.cBAudioDevices);
            this.gbCA80.Controls.Add(this.bExit);
            this.gbCA80.Controls.Add(this.bSaveHex);
            this.gbCA80.Controls.Add(this.bOpenHex);
            this.gbCA80.Controls.Add(this.bOpenBinary);
            this.gbCA80.Controls.Add(this.bSend);
            this.gbCA80.Controls.Add(this.bRescanPorts);
            this.gbCA80.Controls.Add(this.label2);
            this.gbCA80.Controls.Add(this.cBPorts);
            this.gbCA80.Controls.Add(this.tBAddress);
            this.gbCA80.Controls.Add(this.label1);
            this.gbCA80.Location = new System.Drawing.Point(0, 27);
            this.gbCA80.Name = "gbCA80";
            this.gbCA80.Size = new System.Drawing.Size(202, 398);
            this.gbCA80.TabIndex = 2;
            this.gbCA80.TabStop = false;
            this.gbCA80.Text = "CA80";
            // 
            // bPlayAudio
            // 
            this.bPlayAudio.Location = new System.Drawing.Point(12, 275);
            this.bPlayAudio.Name = "bPlayAudio";
            this.bPlayAudio.Size = new System.Drawing.Size(173, 23);
            this.bPlayAudio.TabIndex = 12;
            this.bPlayAudio.Text = "Play";
            this.bPlayAudio.UseVisualStyleBackColor = true;
            this.bPlayAudio.Click += new System.EventHandler(this.bPlayAudio_Click);
            // 
            // cBAudioDevices
            // 
            this.cBAudioDevices.FormattingEnabled = true;
            this.cBAudioDevices.Location = new System.Drawing.Point(12, 248);
            this.cBAudioDevices.Name = "cBAudioDevices";
            this.cBAudioDevices.Size = new System.Drawing.Size(173, 21);
            this.cBAudioDevices.TabIndex = 11;
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(12, 369);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(173, 23);
            this.bExit.TabIndex = 10;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bSaveHex
            // 
            this.bSaveHex.Location = new System.Drawing.Point(15, 77);
            this.bSaveHex.Name = "bSaveHex";
            this.bSaveHex.Size = new System.Drawing.Size(170, 23);
            this.bSaveHex.TabIndex = 9;
            this.bSaveHex.Text = "Save iHEX";
            this.bSaveHex.UseVisualStyleBackColor = true;
            this.bSaveHex.Click += new System.EventHandler(this.bSaveHex_Click);
            // 
            // bOpenHex
            // 
            this.bOpenHex.Location = new System.Drawing.Point(15, 48);
            this.bOpenHex.Name = "bOpenHex";
            this.bOpenHex.Size = new System.Drawing.Size(83, 23);
            this.bOpenHex.TabIndex = 8;
            this.bOpenHex.Text = "Open iHEX";
            this.bOpenHex.UseVisualStyleBackColor = true;
            this.bOpenHex.Click += new System.EventHandler(this.bOpenHex_Click);
            // 
            // bOpenBinary
            // 
            this.bOpenBinary.Location = new System.Drawing.Point(15, 19);
            this.bOpenBinary.Name = "bOpenBinary";
            this.bOpenBinary.Size = new System.Drawing.Size(83, 23);
            this.bOpenBinary.TabIndex = 7;
            this.bOpenBinary.Text = "Open Binary";
            this.bOpenBinary.UseVisualStyleBackColor = true;
            this.bOpenBinary.Click += new System.EventHandler(this.bOpenBinary_Click);
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(12, 210);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(173, 23);
            this.bSend.TabIndex = 5;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bRescanPorts
            // 
            this.bRescanPorts.Location = new System.Drawing.Point(12, 172);
            this.bRescanPorts.Name = "bRescanPorts";
            this.bRescanPorts.Size = new System.Drawing.Size(173, 23);
            this.bRescanPorts.TabIndex = 4;
            this.bRescanPorts.Text = "Rescan";
            this.bRescanPorts.UseVisualStyleBackColor = true;
            this.bRescanPorts.Click += new System.EventHandler(this.bRescanPorts_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // cBPorts
            // 
            this.cBPorts.FormattingEnabled = true;
            this.cBPorts.Location = new System.Drawing.Point(85, 145);
            this.cBPorts.Name = "cBPorts";
            this.cBPorts.Size = new System.Drawing.Size(100, 21);
            this.cBPorts.TabIndex = 2;
            // 
            // tBAddress
            // 
            this.tBAddress.Location = new System.Drawing.Point(85, 114);
            this.tBAddress.Name = "tBAddress";
            this.tBAddress.Size = new System.Drawing.Size(100, 20);
            this.tBAddress.TabIndex = 1;
            this.tBAddress.Text = "C000";
            this.tBAddress.TextChanged += new System.EventHandler(this.tBAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address [hex]";
            // 
            // gBHexView
            // 
            this.gBHexView.Controls.Add(this.tBHexView);
            this.gBHexView.Location = new System.Drawing.Point(208, 29);
            this.gBHexView.Name = "gBHexView";
            this.gBHexView.Size = new System.Drawing.Size(337, 396);
            this.gBHexView.TabIndex = 3;
            this.gBHexView.TabStop = false;
            this.gBHexView.Text = "iHEX";
            // 
            // tBHexView
            // 
            this.tBHexView.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tBHexView.Location = new System.Drawing.Point(6, 14);
            this.tBHexView.Multiline = true;
            this.tBHexView.Name = "tBHexView";
            this.tBHexView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBHexView.Size = new System.Drawing.Size(327, 376);
            this.tBHexView.TabIndex = 0;
            // 
            // bRefreshBinary
            // 
            this.bRefreshBinary.Location = new System.Drawing.Point(104, 19);
            this.bRefreshBinary.Name = "bRefreshBinary";
            this.bRefreshBinary.Size = new System.Drawing.Size(81, 23);
            this.bRefreshBinary.TabIndex = 13;
            this.bRefreshBinary.Text = "Refresh";
            this.bRefreshBinary.UseVisualStyleBackColor = true;
            this.bRefreshBinary.Click += new System.EventHandler(this.bRefreshBinary_Click);
            // 
            // bRefreshHex
            // 
            this.bRefreshHex.Location = new System.Drawing.Point(104, 48);
            this.bRefreshHex.Name = "bRefreshHex";
            this.bRefreshHex.Size = new System.Drawing.Size(81, 23);
            this.bRefreshHex.TabIndex = 14;
            this.bRefreshHex.Text = "Refresh";
            this.bRefreshHex.UseVisualStyleBackColor = true;
            this.bRefreshHex.Click += new System.EventHandler(this.bRefreshHex_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 450);
            this.Controls.Add(this.gBHexView);
            this.Controls.Add(this.gbCA80);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "caloSharp";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbCA80.ResumeLayout(false);
            this.gbCA80.PerformLayout();
            this.gBHexView.ResumeLayout(false);
            this.gBHexView.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBinaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openIHEXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveIHEXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileBinary;
        private System.Windows.Forms.OpenFileDialog openFileHex;
        private System.Windows.Forms.SaveFileDialog saveFileHex;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox gbCA80;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bRescanPorts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBPorts;
        private System.Windows.Forms.TextBox tBAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gBHexView;
        private System.Windows.Forms.TextBox tBHexView;
        private System.Windows.Forms.Button bSaveHex;
        private System.Windows.Forms.Button bOpenHex;
        private System.Windows.Forms.Button bOpenBinary;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ComboBox cBAudioDevices;
        private System.Windows.Forms.Button bPlayAudio;
        private System.Windows.Forms.Button bRefreshHex;
        private System.Windows.Forms.Button bRefreshBinary;
    }
}

