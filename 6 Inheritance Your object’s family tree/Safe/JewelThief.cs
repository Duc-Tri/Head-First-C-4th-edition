using System;

namespace Safe
{
    class JewelThief : Locksmith
    {
        private string stolenJewels;
        protected new void ReturnContents(string safeContents, SafeOwner owner)
        {
            stolenJewels = safeContents;
            Console.WriteLine($"I'm stealing the jewels! I stole: {stolenJewels}");
        }

    }

}
