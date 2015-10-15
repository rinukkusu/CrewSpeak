using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace CrewSpeakServer
{
	public class Server
	{
		TcpListener Listener;
		Dictionary<string, Client> Clients;
		Thread AcceptThread;

		public Server ()
		{
			Clients = new Dictionary<string, Client> ();

			Listener = new TcpListener (9987);
			Listener.Start ();

			AcceptThread = new Thread (TAccept);
			AcceptThread.Start ();
		}

		private void TAccept()
		{
			while (true) {
				if (Listener.Pending ()) {
					TcpClient c = Listener.AcceptTcpClient ();
					if (c.Connected) {
						Guid g = Guid.NewGuid ();
						Client cl = new Client (c, g);
						Clients.Add (g.ToString(), cl);

						Console.WriteLine ("New Client connected: " + g.ToString ());
					}
				}
			}
		}
	}
}

