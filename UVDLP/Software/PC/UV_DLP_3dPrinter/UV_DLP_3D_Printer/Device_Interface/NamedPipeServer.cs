using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using UV_DLP_3D_Printer.Device_Interface;

namespace UV_DLP_3D_Printer.Device_Interface
{
    class NamedPipeServer
    {
        private string _pipeName;
        private bool _running = false;
        private bool _connected = false;
        private bool _waiting = false;
        private NamedPipeServerStream _server;
        private StreamWriter _writer;
        private Thread _serverThread;

        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusUpdated;
        
        public NamedPipeServer(string name)
        {
            _pipeName = name;
        }

        public void Start()
        {
            if (_running) {
                return;
            }
            _running = true;
            _serverThread = new Thread(Run);
            _serverThread.Start();
        }

        public void Stop()
        {
            if (_running) {
                _running = false;
                _serverThread.Interrupt();
            }
        }

        public void Send(string message)
        {
            if (_writer != null) {
                _writer.Write(message);
                _writer.Flush();
            }
        }

        private void Run()
        {
            try {
                while (_running) {
                    if (_server != null) {
                        _writer = null;
                        _server.Dispose();
                        _server = null;
                    }
                    _server = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                    _writer = new StreamWriter(_server, Encoding.Unicode);
                    _waiting = true;
                    _server.BeginWaitForConnection(waiting_callback, null);
                    while (_waiting) {
                        Thread.Sleep(100);
                    }
                    _connected = true;
                    OnConnectionChanged();
                    while (_running) {
                        try {
                            Send("PING");
                        } catch {
                            _connected = false;
                            OnConnectionChanged();
                            break;
                        }
                        Thread.Sleep(250);
                    }
                }
            } catch (ThreadInterruptedException) {
            } finally {
                if (_server != null) {
                    _server.Dispose();
                    _server = null;
                }
            }
         }

        private void waiting_callback(IAsyncResult ar)
        {
            try {
                _waiting = false;
            } finally {
                if (_server != null) {
                    _server.EndWaitForConnection(ar);
                }
            }
        }

        private void OnConnectionChanged()
        {
            if (ConnectionStatusUpdated != null) {
                var handle = ConnectionStatusUpdated;
                handle(this, new ConnectionStatusEventArgs(_connected));
            }
        }
    }
}
