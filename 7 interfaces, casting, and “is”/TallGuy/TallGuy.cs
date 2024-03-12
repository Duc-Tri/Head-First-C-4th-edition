using System;

namespace TallGuy
{
    internal class TallGuy : IClown
    {
        public String Name;
        public int Height;

        public string FunnyThingIHave => "big shoes";

        public void Honk()
        {
            Console.WriteLine("Honk honk !");
        }

        public void TalkAboutYourself()
        {
            Console.WriteLine($"My name is {Name} and I'm {Height} inches tall.");
        }

    }

}
