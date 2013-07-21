using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Device_Interface
{
    public class ClientReadyStatusEventArgs
    {
        public ClientReadyStatusEventArgs(bool _clientReady)
        {
            ClientReady = _clientReady;
        }

        public bool ClientReady { get; set; }
    }
}
