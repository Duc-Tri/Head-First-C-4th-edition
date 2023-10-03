using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicode_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // The ReadAllBytes method returns a reference to a new array of bytes that contains all of the bytes that were read in from the file.
            File.WriteAllText("eureka.txt", "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes("eureka.txt");

            // 69 117 114 101 107 97 33
            foreach (byte b in eurekaBytes) Console.Write("{0} ", b);
            Console.WriteLine();

            foreach (byte b in eurekaBytes) Console.Write("{0:x2} ", b);
            Console.WriteLine();

            Console.WriteLine(Encoding.UTF8.GetString(eurekaBytes));



        }
    }
}
