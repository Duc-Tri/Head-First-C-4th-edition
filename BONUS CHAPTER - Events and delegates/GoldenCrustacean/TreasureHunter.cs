namespace GoldenCrustacean
{
    internal class TreasureHunter
    {
        // And that explains why Henry’s plan backfired. When he added the event handler to the TreasureHunter constructor, he was inadvertently doing the same thing for all of the treasure hunters! And that meant that every treasure hunter’s event handler got chained onto the same RunForCover event. So when the Golden Crustacean ran for cover, everyone was notified about the event. All of that would have been fine if Henry were the first one to get the message. But Henry had no way of knowing when the other treasure hunters would have been called—if they subscribed before he did, they’d get the event first.
        public TreasureHunter(GoldenCrab treasure)
        {
            treasure.RunForCover += treasure_RunForCover;
        }

        // Henry thought he was being clever by altering his class’s constructor to add an event handler that calls his MoveHere method every time the crab raises its RunForCover event. But he forgot that the other treasure hunters inherit from the same class, and his clever code adds their event handlers to the chain, too!
        void treasure_RunForCover(object sender, NewLocationArgs args)
        {
            MoveHere(args.NewLocation);
        }

        void MoveHere(HidingPlace Location)
        {
            // ... code to move to a new location ...
        }

    }
}
