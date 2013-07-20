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
        bool _paused = false;
        private bool _clientReady = false;

        public Main()
        {
            InitializeComponent();
            shpConnected.FillColor = Color.Red;
            shpClientReady.FillColor = Color.Red;
            _server = new NamedPipeServer("3dPrinter");
            _server.ConnectionStatusUpdated += _server_ConnectionStatusUpdated;
            _server.ClientReadyStatusUpdated += _server_ClientReadyStatusUpdated;
            ButtonsEnabled(false);

            _server.Start();

        }

        delegate void UpdateClientStatus(object sender, ClientReadyStatusEventArgs e);
        void _server_ClientReadyStatusUpdated(object sender, ClientReadyStatusEventArgs e)
        {
            if (this.InvokeRequired) {
                var invoker = new UpdateClientStatus(_server_ClientReadyStatusUpdated);
                this.Invoke(invoker, sender, e);
            }
            _clientReady = e.ClientReady;
            ButtonsEnabled(_connected && _clientReady);
            shpClientReady.FillColor = _clientReady ? Color.Lime : Color.Red;
        }

        private void ButtonsEnabled(bool enabled)
        {
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
            btnStartStop.Text = "START";
            btnPause.Text = "PAUSE";
            _started = false;
            _paused = false;
            ButtonsEnabled(_connected && _clientReady);
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
            if (!_started) {
                _paused = false;
                btnPause.Text = "PAUSE";
            } else {
                if (_paused) {
                    _paused = false;
                    _server.Send("START");
                    btnPause.Text = "PAUSE";
                } else {
                    _paused = true;
                    _server.Send("PAUSE");
                    btnPause.Text = "START";
                }
            }
        }

        private void btnPrintSig_Click(object sender, EventArgs e)
        {
            if (_started && !_paused) {
                _server.Send("LAYER_COMPLETED");
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            _server.Stop();
        }
    }
}
