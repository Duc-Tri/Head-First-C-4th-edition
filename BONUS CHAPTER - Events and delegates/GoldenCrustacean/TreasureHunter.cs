namespace GoldenCrustacean
{
    internal class TreasureHunter
    {
        public TreasureHunter(GoldenCrab treasure)
        {
            treasure.RunForCover += treasure_RunForCover;
        }

        void treasure_RunForCover(object sender, NewLocationArgs args)
        {
            MoveHere(args.NewLocation);
        }

        void MoveHere(HidingPlace Location)
        {

        }
    }
}
