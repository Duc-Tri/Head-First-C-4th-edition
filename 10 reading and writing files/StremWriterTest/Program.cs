using System.IO;

namespace StremWriterTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter("secret_plan.txt");
            sw.WriteLine("How i'll defeat Captain Amazing.");
            sw.WriteLine("Another Genius secret plan by the SWINDLER");
            sw.WriteLine("I ll unleash my army of clones upon the citizens of Objectville");

            string location = "the mall";
            for (int number = 1; number <= 5; number++)
            {
                sw.WriteLine("Clone #{0} atacks {1}", number, location);
                location = (location == "the mall") ? "downtown" : "the mall";
            }
            sw.Close();

            StreaWriterMAgnets();
        }

        static void StreaWriterMAgnets()
        {
            //Output file called macaw.txt
            //blue yellow
            //green purple
            //red orange
            Flobbo f = new Flobbo("blue yellow");
            StreamWriter sw = f.Snobbo();
            f.Blobbo(f.Blobbo(f.Blobbo(sw), sw), sw);
        }

    }

    class Flobbo
    {
        private string zap;
        public Flobbo(string zap)
        {
            this.zap = zap;
        }

        public StreamWriter Snobbo()
        {
            return new StreamWriter("macaw.txt");
        }

        public bool Blobbo(StreamWriter sw)
        {
            sw.WriteLine(zap);
            zap = "green purple";
            return false;
        }

        public bool Blobbo(bool Already, StreamWriter sw)
        {
            if (Already)
            {
                sw.WriteLine(zap);
                sw.Close();
                return false;
            }
            else
            {
                sw.WriteLine(zap);
                zap = "red orange";
                return true;
            }
        }

    }

}
