namespace BeehiveManagementSystem
{
    // This Bee subclass overrides DoJob to call the HoneyVault method to convert nectar to honey.

    internal class HoneyManufacturer : Bee
    {
        // its DoJob method passes that const to HoneyVault.ConvertNectarToHoney.
        const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public override float CostPerShift { get => 1.7f; }

        public HoneyManufacturer() : base(BEE_HONEYMANUFACTURER)
        {
        }

        protected override void DoJob()
        {
            HoneyVault.ConverNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }

    }

}
