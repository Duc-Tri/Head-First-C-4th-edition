using System;
using System.IO;
using System.Linq.Expressions;

namespace TryCatchFinally
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstLine = "No first line was read";

            try
            {
                var lines = File.ReadAllLines(args[0]);
                firstLine = (lines.Length > 0) ? lines[0] : "The file was empty";
                int j=0;
                int i = 3 / j;
            }
            catch (System.DivideByZeroException e)
            {
                Console.Error.WriteLine("DivideByZeroException", e);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Could not read lines from the file: {0}", ex);
            }
            finally
            {
                Console.WriteLine(firstLine);
            }

            Console.WriteLine(" ■ this line is after the finally{}, happened if no Exception or when a catch{} triggered ! ");
        }
    }
}
