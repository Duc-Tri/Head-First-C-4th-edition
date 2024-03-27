namespace GoldenCrustacean
{
    internal class NewLocationArgs
    {
        public NewLocationArgs(HidingPlace newLocation)
        {
            this.newLocation = newLocation;
        }

        public NewLocationArgs(string newLocation)
        {
            this.newLocation = new HidingPlace(newLocation);
        }


        private HidingPlace newLocation;
        public HidingPlace NewLocation { get { return newLocation; } }


    }
}
