// this class sends some commands over a named pipe to another program
// controlling a printer
// it _should_ probably implement the DeviceInterface so that it is a
// proper pluggable menu option, but for now, we have just hardwired
// some buttons
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UV_DLP_3D_Printer.Device_Interface;
using UV_DLP_3D_Printer.Drivers;

namespace UV_DLP_3D_Printer.Drivers
{
    public class NamedPipeDriver : DeviceDriver, IDeviceReadyStatus
    {
        public bool Connected { get { return m_connected; } }

        public bool IsDeviceReady { get; private set; }

        private NamedPipeServer _server;

        public NamedPipeDriver()
        {
            m_drivertype = eDriverType.NAMED_PIPE_DRIVER;
            m_connected = false;
            UVDLPApp.Instance().m_buildmgr.PrintStatus += new delPrintStatus(PrintStatus);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            _server = new NamedPipeServer("3dPrinter");
            _server.ConnectionStatusUpdated += _server_ConnectionStatusUpdated;
            _server.ClientReadyStatusUpdated += _server_ClientReadyStatusUpdated;
        }

        void _server_ClientReadyStatusUpdated(object sender, ClientReadyStatusEventArgs e)
        {
            IsDeviceReady = e.ClientReady;
        }

        void _server_ConnectionStatusUpdated(object sender, ConnectionStatusEventArgs e)
        {
            m_connected = e.ClientConnected;
            if (!m_connected) {
                RaiseDeviceStatus(this, eDeviceStatus.eDisconnect);
                DebugLogger.Instance().LogRecord("Named pipe disconnected: Waiting for client to connect");
            } else {
                RaiseDeviceStatus(this, eDeviceStatus.eConnect);
                DebugLogger.Instance().LogRecord("Named pipe client (printer) has connected.");
            }
        }

        public override bool Disconnect()
        {
            if (this.Connected)
            {
                _server.Stop();
                m_connected = false;
                RaiseDeviceStatus(this, eDeviceStatus.eDisconnect);
            }
            return true;
        }


        public override bool Connect()
        {
            if (m_connected) {
                return true;
            }
            DebugLogger.Instance().LogRecord("Starting named pipe driver");
            _server.Start();
            var count = 0;
            while (!Connected) {
                DebugLogger.Instance().LogRecord("Waiting for client to connect");
                count++;
                if (count > 20) {
                    Disconnect();
                    return false;
                }
                Thread.Sleep(1500);
            }
            return true;
        }

        public void StartPrint()
        {
            if (this.Connected)
            {
                _server.Send("START");
                DebugLogger.Instance().LogRecord("Named pipe sent: START");
            }
            else
            {
                DebugLogger.Instance().LogRecord("Named pipe not connected, could not send: START");
            }
        }

        public void PausePrint()
        {
            if (this.Connected)
            {
                _server.Send("PAUSE");
                DebugLogger.Instance().LogRecord("Named pipe sent: PAUSE");
            }
            else
            {
                DebugLogger.Instance().LogRecord("Named pipe not connected, could not send: PAUSE");
            }
        }

        public void CancelPrint()
        {
            if (this.Connected)
            {
                _server.Send("CANCEL");
                DebugLogger.Instance().LogRecord("Named pipe sent: CANCEL");
            }
            else
            {
                DebugLogger.Instance().LogRecord("Named pipe not connected, could not send: CANCEL");
            }
        }

        internal void PrintStatus(ePrintStat printstat)
        {
            switch (printstat)
            {
                case ePrintStat.ePrintPaused:
                    PausePrint();
                    break;
                case ePrintStat.ePrintResumed:
                    StartPrint();
                    break;
                case ePrintStat.ePrintCancelled:
                    CancelPrint();
                    break;
                case ePrintStat.eLayerCompleted:
                    SignalLayerCompleted();
                    break;
                case ePrintStat.ePrintCompleted:
                    CancelPrint();
                    break;
                case ePrintStat.ePrintStarted:
                    StartPrint();
                    break;
            }
        }

        private void SignalLayerCompleted()
        {
            // Sync signal
            if (this.Connected) {
                _server.Send("LAYER_COMPLETED");
                // DebugLogger.Instance().LogRecord("sent LAYER_COMPLETED to ProfiLab");
            } else {
                DebugLogger.Instance().LogRecord("Named pipe not connected, could not send: LAYER_COMPLETED");
            }
        }

        internal void PrintLayer(System.Drawing.Bitmap bmplayer, int layernum, int layertype)
        {
            // OK
        }

        public override int Write(byte[] data, int len)
        {
            return len; // Don't care
        }

        public override int Write(string line)
        {
            return line.Length; //Don't care
        }
    }
}
