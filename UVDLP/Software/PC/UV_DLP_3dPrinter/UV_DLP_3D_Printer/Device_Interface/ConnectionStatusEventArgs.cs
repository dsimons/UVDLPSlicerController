using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Device_Interface
{
    internal class ConnectionStatusEventArgs : EventArgs
    {
        public ConnectionStatusEventArgs(bool clientConnected)
        {
            ClientConnected = clientConnected;
        }

        public bool ClientConnected { get; private set; }
    }
}
