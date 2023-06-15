using System;
using System.Windows.Controls;

namespace BeehiveManagementSystem
{
    // This Bee subclass uses an array to keep track of the workers  and overrides DoJob to call their WorkTheNextShift methods.
    //The Queen class drives all of the work in the program—she keeps track of the instances     of the worker Bee objects, creates new ones when they need to be assigned to their jobs, and tells them to start working their shifts:

    internal class Queen : Bee
    {
        private const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private Bee[] workers = new Bee[0];
        private float eggs = 0;
        private float unassignedWorkers;
        public string StatusReport { get; private set; }
        public override float CostPerShift { get => 2.15f; }

        public Queen() : base(BEE_QUEEN)
        {

            // She starts off with three unassigned workers—her constructor calls the AssignBee method three times to create three worker bees, one of each type.
            eggs = 0;
            unassignedWorkers = 3; // IMPORTANT !
            AssignBee(BEE_NECTARCOLLECTOR);
            AssignBee(BEE_HONEYMANUFACTURER);
            AssignBee(BEE_EGGCARE);
        }

        /// <summary>
        /// Expand the workers array by one slot and add a Bee reference.
        /// </summary>
        /// <param name="worker">Worker to add to the workers array.</param>
        private void AddWorker(Bee worker)
        {
            if (unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        // The EggCare bees call the Queen’s CareForEggs method. It takes a float parameter called eggsToConvert. If the eggs field is >= eggsToConvert, it subtracts eggsToConvert from eggs and adds it to unassignedWorkers.
        public void CareForEggs(float eggsToConvert)
        {
            // decreases eggs and increases unassignedWorkers.
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

        // UpdateStatusReport calls a private WorkerStatus method with a string parameter called job (""Nectar Collector"") and returns a string with the number of workers doing that job (""3 Nectar Collector bees"")."
        private void UpdateStatusReport()
        {
            // Look carefully at the status reports in the screenshot—her private UpdateStatusReport method generates it (using HoneyVault.StatusReport). She calls UpdateStatusReport at the end of her DoJob and AssignBee methods.

            // UpdateStatusReport calls a private WorkerStatus method with a string parameter called job("Nectar Collector") and returns a string with the number of workers doing that job("3 Nectar Collector bees").

            StatusReport = HoneyVault.StatusReport + "\n==========================\n" +
                "■ " + eggs + " Eggs\n■ " +
                unassignedWorkers + " unassigned Workers\n■ " +
                WorkerStatus(BEE_EGGCARE) + "\n■ " +
                WorkerStatus(BEE_NECTARCOLLECTOR) + "\n■ " +
                WorkerStatus(BEE_HONEYMANUFACTURER) +
                "\n TOTAL WORKERS ■■■■■ " + workers.Length;
        }

        private string WorkerStatus(string j)
        {
            int n = 0;
            foreach (var worker in workers) if (worker.Job == j) n++;

            return n + " " + j;
        }

        //  It uses a switch statement to create a new instance of the appropriate Bee subclass and pass it to AddWorker
        public void AssignBee(string job)
        {
            Console.WriteLine("AssignBee: " + job);

            switch (job)
            {
                case BEE_EGGCARE:
                    AddWorker(new EggCare(this));
                    break;

                case BEE_HONEYMANUFACTURER:
                    AddWorker(new HoneyManufacturer());
                    break;

                case BEE_NECTARCOLLECTOR:
                    AddWorker(new NectarCollector());
                    break;
            }

            UpdateStatusReport();
        }

        // Add eggs, tell the worker bees to work, and feed honey to the unassigned workers waiting for work.The EGGS_PER_SHIFT constant(set to 0.45f) is added to the eggs field.She uses a foreach loop to call each worker’s WorkTheNextShift method.Then she calls HoneyVault.ConsumeHoney, passing it the constant HONEY_PER_UNASSIGNED_WORKER (set to 0.5f) × unassignedWorkers.
        protected override void DoJob()
        {
            // Adds 0.45 eggs to her private eggs field(using a const called EGGS_PER_SHIFT).
            eggs += EGGS_PER_SHIFT;

            // Then it uses a foreach loop to call each worker’s WorkTheNextShift method.
            foreach (var worker in workers)
                worker.WorkTheNextShift();

            // It consumes honey for each unassigned worker.The             HONEY_PER_UNASSIGNED_WORKER const tracks how much each one consumes per shift.
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * unassignedWorkers);

            //  Finally, it calls its UpdateStatusReport method.
            UpdateStatusReport();
        }

    }
}
