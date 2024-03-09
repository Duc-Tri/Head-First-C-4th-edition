using System;

namespace ChainedEventHandlers
{
    internal class Talker
    {
        public event EventHandler<TalkEventArgs> TalkToMe;

        public void OnTalkToMe(string message) => TalkToMe?.Invoke(this, new TalkEventArgs(message));
    }

}
