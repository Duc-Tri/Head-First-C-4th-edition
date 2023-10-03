using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HexDump
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var position = 0;
            // A StreamReader’s EndOfStream property returns false if there are characters still left to read in the file.

            //using (var reader = new StreamReader("textdata.txt")) // "binarydata.dat"
            using (Stream input = File.OpenRead(args[0]))
            {
                var buffer = new byte[16];
                int bytesRead;
                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // Read up to the next 16 bytes from the file into a byte array

                    // The {0:x4} formatter converts a numeric value to a four-digit hex number, so 1984 is converted to the string “07c0”.
                    // Write the position (or offset) in hex, followed by a colon and space
                    Console.Write("{0:x4}: ", position);
                    position += bytesRead;

                    // Write the hex value of each character in the byte array
                    // This loop goes through the characters and prints each of them to a line in the output.
                    for (var i = 0; i < 16; i++)
                    {
                        if (i < bytesRead)
                            Console.Write("{0:x2} ", (byte)buffer[i]);
                        else
                            Console.Write(" ");

                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';

                        if (i == 7) Console.Write("-- ");
                    }

                    // Write the actual characters in the byte array
                    var bufferContents = Encoding.UTF8.GetString(buffer);

                    // The String.Substring method returns a part of a string.The first parameter is the starting position(in this case, the beginning of the string), and the second is the number of characters to include in the substring. The String class has an overloaded constructor that takes a char array as a parameter and converts it to a string.
                    Console.WriteLine(" {0}", bufferContents.Substring(0, bytesRead));
                }
            }
        }
    }

}
