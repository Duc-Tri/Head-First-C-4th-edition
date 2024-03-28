namespace GoldenCrustacean
{
    internal class GoldenCrab
    {
        public delegate void Escape(object sender, NewLocationArgs args);

        public event Escape RunForCover;

        // Any time someone comes close to the golden crab, its SomeonesNearby method fires off a RunForCover event, and it finds a place to hide.
        public void SomesNearby() => RunForCover?.Invoke(this, new NewLocationArgs("Under the rock"));
    }
}

