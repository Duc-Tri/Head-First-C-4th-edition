using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeehiveManagementSystem
{
    // The NectarCollector class collects nectar each shift and adds it to the vault (overrides DoJob to call the HoneyVault method to collect nectar.)
    internal class NectarCollector : Bee
    {
        // Its DoJob method passes that const to HoneyVault.CollectNectar
        const float NECTAR_COLLECTED_PER_SHIFT = 33.25f;

        public override float CostPerShift => 1.95f;

        public NectarCollector() : base(BEE_NECTARCOLLECTOR)
        {
        }

        protected override void DoJob() => HoneyVault.CollectNectar(NECTAR_COLLECTED_PER_SHIFT);
    }
}
