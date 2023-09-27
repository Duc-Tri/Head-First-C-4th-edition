using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryStreamTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The MemoryStream is declared in the outer using block so it can stay open even after the StreamWriter is closed.
            using (var ms = new MemoryStream())
            {
                // The inner using block makes sure the StreamWriter is closed before the MemoryStream.ToArray method gets called.
                using (var sw = new StreamWriter(ms))
                {
                    sw.WriteLine("The value is {0:0.00}", 123.45678);
                }

                Console.WriteLine("===============================");
                Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            }
        }
    }
}
