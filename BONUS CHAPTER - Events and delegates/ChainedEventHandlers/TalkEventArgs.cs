using System;

namespace ChainedEventHandlers
{
    internal class TalkEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public TalkEventArgs(string message) => Message = message;
    }

}
