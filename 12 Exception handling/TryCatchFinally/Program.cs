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
                int j = 0;
                int i = 3 / j;
            }
            catch (IndexOutOfRangeException)
            {
                Console.Error.WriteLine(" ! Please specify a filename.");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine(" ! Unable to find file: {0}", args[0]);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine(" ! File {0} could not be accessed: {1}",
                args[0], ex.Message);
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
                Console.WriteLine(" ■ FINALLY " + firstLine);
            }

            Console.WriteLine(" ■ this line is after the finally{}, happened if no Exception or when a catch{} triggered ! ");
        }
    }
}
