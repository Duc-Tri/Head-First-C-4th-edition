using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainedEventHandlers
{
    internal class TalkEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public TalkEventArgs(string message) => Message = message;
    }



}
