using System;
using System.IO.Ports;

public class Calo
{
	public Calo(SerialPort &serial, int baud = 19200)
	{
		_serial = serial;

		_serial.BaudRate = baud;
		_serial.Parity = Parity.None;
		_serial.StopBits = StopBits.One;
		_serial.DataBits = 8;

        try
        {
			_serial.Open();
        }
		catch
        {
			_ret = retCode.PortError;
        }

	}

	public ~Calo()
    {
		if (_serial.IsOpen())
			_serial.Close();
    }

	private:
		SerialPort _serial;
		retCode _ret;

	public:
		enum retCode
		{
			OK = 0,
			PortError,
	    };
}
