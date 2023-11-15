using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace TryCatchFinally
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorielle(60));
            Dummy d = new Dummy();
            Console.WriteLine(d);
            Console.WriteLine(d.lints);
            TryCatchFinallyTest(null);
        }

        private static ulong Factorielle(ulong v)
        {
            return (v > 1) ? (v * Factorielle(v - 1)) : 1;
        }

        static void TryCatchFinallyTest(string filename)
        {
            var firstLine = "No first line was read";

            try
            {
                var lines = File.ReadAllLines(filename); // args[0]
                firstLine = (lines.Length > 0) ? lines[0] : "The file was empty";
                int j = 0;
                int i = 3 / j;
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine(" ! Please specify a filename.");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(" ! Unable to find file: {0}", filename); // args[0]
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine(" ! File {0} could not be accessed: {1}",
                filename, ex.Message); // args[0]
            }
            catch (System.DivideByZeroException e)
            {
                Console.Error.WriteLine(" ! DivideByZeroException", e);
            }
            catch (Exception)
            {
                Console.Error.WriteLine(" ! AVOID CATCH-ALL EXCEPTION !");
            }
            finally
            {
                Console.WriteLine(" ■ FINALLY : " + firstLine);
            }

            Console.WriteLine(" ■ this line is after the finally{}, happened if no Exception or when a catch{} triggered !");
        }

    }

    public class Dummy
    {
        public List<int> lints;

        public Dummy()
        {
            try
            {
                int i = 0;
                i = 1 / i;
            }
            catch // catch-all
            {
            }
            finally
            {
                lints = new List<int>();
            }
        }
    }
}
