using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest
{
    class PrintWhenGetting
    {
        private int instanceNumber;
        public int InstanceNumber
        {
            set { instanceNumber = value; }
            get
            {
                Console.WriteLine($"Getting #{instanceNumber}");
                return instanceNumber;
            }
        }
    }
}
