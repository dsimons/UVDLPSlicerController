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

namespace UV_DLP_3D_Printer
{
    public class NamedPipeDriver
    {
        public bool Connected { get; set; }
        public NamedPipeServerStream m_stream = null;
        public StreamReader m_reader;
        public StreamWriter m_writer;
        public ManualResetEvent m_signal;

        public NamedPipeDriver()
        {
            this.Connected = false;
        }

        public void Disconnect()
        {
            if (this.Connected)
            {
                this.Connected = false;
                m_signal.Set();
                m_stream.Close();
                m_stream.Dispose(); m_stream = null;
                m_reader.Dispose(); m_reader = null;
                m_writer.Dispose(); m_writer = null;
                DebugLogger.Instance().LogRecord("disconnected from ProfiLab");
            }
            else
            {
                DebugLogger.Instance().LogRecord("was already disconnected from ProfiLab");
            }
        }

        public IAsyncResult ConnectStream()
        {
            // http://stackoverflow.com/questions/2700472/how-to-terminate-a-managed-thread-blocked-in-unmanaged-code
            m_signal = new ManualResetEvent(false);

            // mode MESSAGE?
            m_stream = new NamedPipeServerStream("3dPrinter", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            IAsyncResult asyncResult = m_stream.BeginWaitForConnection(_ => m_signal.Set(), null);
            DebugLogger.Instance().LogRecord("ready for connection from ProfiLab");
            m_signal.WaitOne();

            if (asyncResult.IsCompleted)
            {
                DebugLogger.Instance().LogRecord("got connection from ProfiLab");
                m_stream.EndWaitForConnection(asyncResult);
                m_reader = new StreamReader(m_stream);
                m_writer = new StreamWriter(m_stream);
                m_writer.WriteLine("CONNECT CreationWorkshop");
                m_writer.Flush();
            }
            else
            {
                DebugLogger.Instance().LogRecord("no connection from ProfiLab");
                DisconnectStream();
            }
            
            return asyncResult;
        }

        public void DisconnectStream()
        {
            if (m_stream == null)
            {
                return;
            }
            DebugLogger.Instance().LogRecord("disconnect from ProfiLab");
            m_stream.Disconnect();
            m_stream.Close();
            m_stream = null;
            m_reader = null;
            m_writer = null;
        }

        public void Connect()
        {
            if (this.Connected)
            {
                DebugLogger.Instance().LogRecord("already connected to ProfiLab");
                return;
            }

            this.Connected = true;

            Task.Factory.StartNew(() =>
            {
                IAsyncResult asyncResult = ConnectStream();
                if (asyncResult.IsCompleted)
                {
                    Task<string> t = null;

                    while (this.Connected)
                    {
                        if (m_stream.IsConnected)
                        {
                            if (t == null)
                            {
                                t = m_reader.ReadLineAsync();
                                t.Wait(100);
                            }
                            if (t.IsCompleted)
                            {
                                string result = t.Result;
                                DebugLogger.Instance().LogRecord("PROFILAB: " + m_reader.ReadLine());
                            }
                        }
                        else
                        {
                            t.Dispose(); // try to cancel
                            t = null;
                            DisconnectStream();
                            ConnectStream();
                        }
                    }
                    DisconnectStream();
                }
                else
                {
                    this.Connected = false;
                }
            });
        }

        public void StartPrint()
        {
            if (this.Connected && m_stream.IsConnected)
            {
                m_writer.WriteLineAsync("START"); m_writer.FlushAsync();
                DebugLogger.Instance().LogRecord("sent START to ProfiLab");
            }
            else
            {
                DebugLogger.Instance().LogRecord("could not send START to ProfiLab");
            }
        }

        public void PausePrint()
        {
            if (this.Connected && m_stream.IsConnected)
            {
                m_writer.WriteLineAsync("PAUSE"); m_writer.FlushAsync();
                DebugLogger.Instance().LogRecord("sent PAUSE to ProfiLab");
            }
            else
            {
                DebugLogger.Instance().LogRecord("could not send PAUSE to ProfiLab");
            }
        }

        public void CancelPrint()
        {
            if (this.Connected && m_stream.IsConnected)
            {
                m_writer.WriteLineAsync("CANCEL"); m_writer.FlushAsync();
                DebugLogger.Instance().LogRecord("sent CANCEL to ProfiLab");
            }
            else
            {
                DebugLogger.Instance().LogRecord("could not send CANCEL to ProfiLab");
            }
        }
    }
}
