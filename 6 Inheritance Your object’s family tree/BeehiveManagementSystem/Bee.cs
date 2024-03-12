namespace BeehiveManagementSystem
{
    // Bee is the base class for all of the bee classes. Its WorkTheNextShift method calls the Honey Vault's ConsumeHoney method, and if it returns true calls DoJob.
    internal abstract class Bee : IWorker
    {
        public const string BEE_QUEEN = "Queen";
        public const string BEE_EGGCARE = "EggCare";
        public const string BEE_HONEYMANUFACTURER = "HoneyManufacturer";
        public const string BEE_NECTARCOLLECTOR = "NectarCollector";

        public string Job { get; private set; }
        public virtual float CostPerShift { get; }

        public Bee(string j)
        {
            Job = j;
        }

        public virtual void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
                DoJob();
        }

        protected virtual void DoJob()
        {

        }

    }

}
