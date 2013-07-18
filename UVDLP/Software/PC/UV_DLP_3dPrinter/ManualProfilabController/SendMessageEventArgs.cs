using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManualProfilabController
{
    class SendMessageEventArgs : EventArgs
    {
        public SendMessageEventArgs(string message)
        {
            MessageToSend = message;
        }

        public string MessageToSend { get; private set; }
    }
}
