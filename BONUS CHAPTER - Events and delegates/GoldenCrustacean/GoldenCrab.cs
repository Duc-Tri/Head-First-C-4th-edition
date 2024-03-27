using System.Runtime.CompilerServices;

namespace GoldenCrustacean
{
    internal class GoldenCrab
    {
        public delegate void Escape(object sender, NewLocationArgs args);

        public event Escape RunForCover;

        public void SomesNearby() => RunForCover?.Invoke(this, new NewLocationArgs("Under the rock"));
    }
}

