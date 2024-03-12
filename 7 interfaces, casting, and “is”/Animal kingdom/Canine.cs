namespace Animal_kingdom
{
    // The abstract Canine class extends Animal. It hasits own abstract property, BelongsToPack.
    abstract class Canine : Animal
    {
        public bool BelongsToPack { get; protected set; } = false;

    }

}
