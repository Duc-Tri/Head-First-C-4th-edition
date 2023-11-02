using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GCTests
{
    class EvilClone
    {
        public static int CloneCount = 0;
        public int CloneID { get; } = ++CloneCount;
        public EvilClone() => Console.WriteLine("Clone #{0} is wreaking havoc", CloneID);

// In general, you’ll never write a finalizer for an object that only owns managed resources. Everything you’ve encountered so far in this book has been managed by the CLR. But occasionally programmers need to access a Windows resource that isn’t in a .NET namespace. For example, if you find code on the internet that has[DllImport] above a declaration, you might be using an unmanaged resource.And some of those non-.NET resources might leave your system unstable if they’re not “cleaned up.” That’s what finalizers are for. This is the finalizer (sometimes called a “destructor”). It’s declared as a method that starts with a tilde ~and has no return value or parameters. An object’s  finalizer is run just before the object is garbage-collected. 
        ~EvilClone()
        {
            Console.WriteLine("Clone #{0} destroyed", CloneID);
        }
    }
}


