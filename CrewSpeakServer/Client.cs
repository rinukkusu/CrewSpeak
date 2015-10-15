using System;
using System.Net.Sockets;
using System.Threading;

namespace CrewSpeakServer
{
	public class Client
	{
		TcpClient ClientInstance;
		Thread ReaderThread;
		public Guid ClientGuid { get; private set; }

		public Client (TcpClient instance, Guid clientGuid)
		{
			ClientInstance = instance;
			ClientGuid = clientGuid;

			ReaderThread = new Thread (TReader);
			ReaderThread.Start ();
		}

		private void TReader()
		{
			while (ClientInstance.Connected) {
				if (ClientInstance.GetStream ().DataAvailable) {
					byte[] buffer = new byte[4096];

					ClientInstance.GetStream ().Read (buffer, 0, 4096);
				}
			}
		}
	}
}

