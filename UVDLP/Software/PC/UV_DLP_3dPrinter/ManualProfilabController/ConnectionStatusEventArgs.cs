using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManualProfilabController
{
    class ConnectionStatusEventArgs : EventArgs
    {
        public ConnectionStatusEventArgs(bool clientConnected)
        {
            ClientConnected = clientConnected;
        }

        public bool ClientConnected { get; private set; }
    }
}
