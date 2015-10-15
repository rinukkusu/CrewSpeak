using System;
using System.Windows;
using System.Windows.Forms;
using System.Collections.Generic;

namespace CrewSpeak
{
	public class MainWindow : Form
	{
		Server S;

		public MainWindow ()
		{
			S = new Server ("localhost", 9987, "", "");
			if (!S.Connect ()) {
				Text = "Failed ...";
			}


		}
	}
}

