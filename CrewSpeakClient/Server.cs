using System;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace CrewSpeakClient
{
	public class Server
	{
		public string Hostname { get; private set; }
		public int Port { get; private set; }
		public string Password { get; private set; }
		public string Nickname { get; set; }

		private TcpClient Connection;
		private StreamReader Reader;
		private StreamWriter Writer;

		private Thread ReaderThread;

		private AudioEngine Audio;

		public Server (string hostname, int port, string password, string nickname)
		{
			Hostname = hostname;
			Port = port;
			Password = password;
			Nickname = nickname;
		}

		public bool Connect()
		{
			Connection = new TcpClient ();

			try {
				Connection.Connect (Hostname, Port);
			}
			catch {
				return false;
			}

			if (!Connection.Connected) {
				return false;
			}

			ReaderThread = new Thread (TReader);
			ReaderThread.Start ();

			Audio = new AudioEngine (this);

			RandomBufferGenerator gen = new RandomBufferGenerator (102400);

			Audio.PlayRawAudio(gen.GenerateBufferFromSeed(102400));

			return true;
		}

		private void TReader()
		{
			Reader = new StreamReader (Connection.GetStream ());
			Writer = new StreamWriter (Connection.GetStream ());

			while (Connection.Connected) {
				try {
					
				}
				catch (Exception ex) {
					
				}
			}
		}

		public void Write(byte[] bytes, int bytecount)
		{
			Connection.GetStream ().WriteAsync(bytes, 0, bytecount);
			Connection.GetStream ().FlushAsync();
		}
	}
}

