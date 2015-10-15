using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrewSpeakClient
{
    public partial class frmMain : Form
    {
        Server S;

        public frmMain()
        {
            InitializeComponent();

            S = new Server("localhost", 9987, "", "");
            if (!S.Connect())
            {
                Text = "Failed ...";
            }
        }
    }
}
