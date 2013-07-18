using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManualProfilabController
{
    public partial class Main : Form
    {
        NamedPipeServer _server;
        bool _connected = false;
        bool _started = false;

        public Main()
        {
            InitializeComponent();
            shpConnected.FillColor = Color.Red;
            _server = new NamedPipeServer("3dPrinter");
            _server.ConnectionStatusUpdated += _server_ConnectionStatusUpdated;

            ButtonsEnabled(false);

            _server.Start();

        }

        private void ButtonsEnabled(bool enabled)
        {
            btnStartStop.Text = "START";
            _started = false;
            btnStartStop.Enabled = enabled;
            btnPause.Enabled = enabled;
            btnPrintSig.Enabled = enabled;
        }

        delegate void UpdateConnectionStatus(object sender, ConnectionStatusEventArgs e);
        void _server_ConnectionStatusUpdated(object sender, ConnectionStatusEventArgs e)
        {
            if (this.InvokeRequired) {
                var invoker = new UpdateConnectionStatus(_server_ConnectionStatusUpdated);
                this.Invoke(invoker, sender, e);
            }
            _connected = e.ClientConnected;
            ButtonsEnabled(_connected);
            shpConnected.FillColor = _connected ? Color.Lime : Color.Red;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_started) {
                _server.Send("CANCEL");
                btnStartStop.Text = "START";
                _started = false;
            } else {
                _server.Send("START");
                btnStartStop.Text = "STOP";
                _started = true;
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            _server.Send("PAUSE");
        }

        private void btnPrintSig_Click(object sender, EventArgs e)
        {
            _server.Send("LAYER_COMPLETED");
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Stop();
        }
    }
}
