using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagementSystem
{
    // This Bee subclass keeps a reference to the Queen, and overrides DoJob to call the Queen’s CareForEggs method.

    internal class EggCare : Bee
    {
        // its DoJob method passes that const to queen.CareForEggs, using a private Queen reference that’s initialized in the EggCare constructor.
        const float CARE_PROGRESS_PER_SHIFT = 0.15f;

        public override float CostPerShift { get => 1.35f; }

        static Queen myQueen;

        public EggCare(Queen q) : base(BEE_EGGCARE)
        {
            myQueen = q;
        }

        protected override void DoJob()
        {
            myQueen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }

    }
}
