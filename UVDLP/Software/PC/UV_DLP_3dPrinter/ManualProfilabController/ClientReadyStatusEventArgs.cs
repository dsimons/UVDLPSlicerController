using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManualProfilabController
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
