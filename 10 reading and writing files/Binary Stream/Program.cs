using System;
using System.IO;

namespace Binary_Stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====BinaryWriterTest");
            BinaryWriterTest();
            Console.WriteLine("=====BinaryReaderTest");
            BinaryReaderTest();
            Console.WriteLine("=====BinaryReaderTest2");
            BinaryReaderTest2();

        }

        static void BinaryWriterTest()
        {
            int intValue = 48769414;
            string stringValue = "Hello!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695F;
            char charValue = 'E';

            // If you use File.Create, it’ll start a new file—if there’s one there already, it’ll blow it away and start a brand-new one.The File.OpenWrite method opens the existing one and starts overwriting it from the beginning instead.
            using (var output = File.Create("binarydata.dat"))
            using (var writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(floatValue);
                writer.Write(charValue);

                // Each Write statement encodes one value into bytes, and then sends those bytes to the FileStream object.You can pass it any value type, and it’ll encode it automatically.
            }

        }

        static void BinaryReaderTest()
        {
            byte[] dataWritten = File.ReadAllBytes("binarydata.dat");
            foreach (byte b in dataWritten) Console.Write("{0:x2} ", b);
            Console.WriteLine(" - {0} bytes", dataWritten.Length);

            // 86 29 e8 02 06 48 65 6c 6c 6f 21 2f 81 00 74 f6 d8 f5 43 45  - 20 bytes
            // float and int values take up four bytes when you write them to a file. If you’d used long or double, then they’d take up eight bytes each.

        }

        static void BinaryReaderTest2()
        {
            using (var input = File.OpenRead("binarydata.dat"))
            using (var reader = new BinaryReader(input))
            {
                // BinaryReader that returns the data in the correct type.Most don’t need any parameters, but ReadBytes takes one parameter that tells BinaryReader how many bytes to read.

                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.Write("int: {0} string: {1} bytes: ", intRead, stringRead);
                foreach (byte b in byteArrayRead) Console.Write("{0} ", b);

                Console.Write(" float: {0} char: {1} ", floatRead, charRead);
            }

        }
    }
}