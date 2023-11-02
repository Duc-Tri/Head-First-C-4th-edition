using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GCTests
{
    // The Main method instantiates EvilClone objects, dereferences (or removes references to) them, and collects them:
    class Program
    {
        // Run your app and press a a few times to create some EvilClone objects and add them to the List. Then press c to clear the List and remove all references to those EvilClone objects. Press c a few times—there’s a small chance the CLR will collect some of the objects that were dereferenced, but you probably won’t see them collected until you press g to call GC.Collect.

        static void Main(string[] args)
        {
            // We’ll use Stopwatch to get an idea of how fast garbage collection runs.The Stopwatch class lets you accurately measure elapsed time by starting a new stopwatch and getting the number of milliseconds elapsed since you started it.
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            var clones = new List<EvilClone>();
            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    // When you press the ‘a’ key your app creates a new instance of EvilClone and adds it to the clones List.
                    case 'a':
                        clones.Add(new EvilClone());
                        break;
                    // Pressing ‘c’ tells the app to clear the List, removing all references to—or dereferencing—all of the clones that you instantiated and added.
                    case 'c':
                        Console.WriteLine("Clearing list at time {0}", stopwatch.ElapsedMilliseconds);
                        clones.Clear();
                        break;
                    // Pressing ‘g’ tells the CLR to collect all objects that have been marked for garbage collection.
                    case 'g':
                        Console.WriteLine("Collecting at time {0}", stopwatch.ElapsedMilliseconds);
                        GC.Collect();
                        break;
                };
            }
        }


    }
}
