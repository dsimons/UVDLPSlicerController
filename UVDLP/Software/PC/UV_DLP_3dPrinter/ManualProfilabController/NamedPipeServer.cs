using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManualProfilabController
{
    class NamedPipeServer
    {
        private string _pipeName;
        private bool _running = false;
        private bool _connected = false;
        private bool _waiting = false;
        private bool _clientReady = false;
        private NamedPipeServerStream _server;
        private StreamWriter _writer;
        private Thread _serverThread;

        public event EventHandler<ConnectionStatusEventArgs> ConnectionStatusUpdated;
        public event EventHandler<ClientReadyStatusEventArgs> ClientReadyStatusUpdated;
        private StreamReader _reader;

        public NamedPipeServer(string name)
        {
            _pipeName = name;
        }

        public void Start()
        {
            _running = true;
            _serverThread = new Thread(Run);
            _serverThread.IsBackground = true;
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

        public string Read()
        {
            try {
                if (_reader != null) {
                    var buffer = new char[256];
                    var readbytescount = _reader.Read(buffer, 0, 256);
                    if (readbytescount > 0) {
                        return new string(buffer.Take(readbytescount).ToArray());
                    } else {
                        return null;
                    }
                } else {
                    return null;
                }
            } catch {
                return null;
            }
        }

        private void Run()
        {
            try {
                while (_running) {
                    if (_server != null) {
                        _writer = null;
                        _reader = null;
                        _server.Dispose();
                        _server = null;
                    }
                    _server = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                    _writer = new StreamWriter(_server, Encoding.Unicode);
                    _reader = new StreamReader(_server, Encoding.Unicode);
                    _waiting = true;
                    _server.BeginWaitForConnection(waiting_callback, 1);
                    while (_waiting) {
                        Thread.Sleep(500);
                    }
                    _connected = true;
                    OnConnectionChanged();
                    while (_running) {
                        try {
                            UpdateClientReadyStatus();
                        } catch {
                            _connected = false;
                            OnConnectionChanged();
                            break;
                        }
                        Thread.Sleep(100);
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

        private void UpdateClientReadyStatus()
        {
            Send("GET_READY_STATUS");
            var response = Read();
            bool ready;
            if (response == "READY") {
                ready = true;
            } else {
                ready = false;
            }
            if (_clientReady != ready) {
                _clientReady = ready;
                OnClientReadyChanged();
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

        private void OnClientReadyChanged()
        {
            if (ClientReadyStatusUpdated != null) {
                var handle = ClientReadyStatusUpdated;
                handle(this, new ClientReadyStatusEventArgs(_clientReady));
            }
        }
    }
}
