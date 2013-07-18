using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;

namespace ManualProfilabController
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
            _running = true;
            _serverThread = new Thread(Run);
            _serverThread.Start();
        }

        public void Stop()
        {
            _running = false;
            _serverThread.Interrupt();
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
                    _server.BeginWaitForConnection(waiting_callback, 1);
                    while (_waiting) {
                        Thread.Sleep(500);
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
                        _server.WaitForPipeDrain();
                        Thread.Sleep(1000);
                    }
                }
            } catch (ThreadInterruptedException) {
            } finally {
                _server.Dispose();
                _server = null;
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
