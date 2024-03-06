using System;

namespace BaseBall
{
    internal class BallEventArgs : EventArgs
    {
        public int Angle { get; private set; }
        public int Distance { get; private set; }
        public BallEventArgs(int angle, int distance)
        {
            this.Angle = angle;
            this.Distance = distance;
        }

    }

}
