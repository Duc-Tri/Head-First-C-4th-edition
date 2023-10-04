using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hide_and_Seek
{
    // GameController uses the static House class, but since it’s static it doesn’t     keep a reference to it.
    internal class GameController
    {
        internal string Status;
        internal string Prompt;

        internal bool ParseInput(string v)
        {
            throw new NotImplementedException();
        }
    }
}
