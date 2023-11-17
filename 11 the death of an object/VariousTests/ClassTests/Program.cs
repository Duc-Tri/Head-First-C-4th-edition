using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;

namespace ClassTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Factorielle(60));

            Console.WriteLine("-------------");

            TestAbstractOverrideNew();
        }

        private static void TestAbstractOverrideNew()
        {
            // TypeA impossible = new TypeA();  // IMPOSSIBLE to instantiate an abstract class

            Console.WriteLine("===== Child class, child type instantiate, override method");
            ChildTypeB childTypeB = new ChildTypeB();
            childTypeB.MethodAbstract();
            childTypeB.MethodVirtual();

            Console.WriteLine("===== Child class, child type instantiate, new method");
            ChildTypeC childTypeC = new ChildTypeC();
            childTypeC.MethodAbstract();
            childTypeC.MethodVirtual();

            Console.WriteLine("===== Abstract class, child type instantiate, override method");
            TypeA weirdoB = new ChildTypeB();
            weirdoB.MethodAbstract();
            weirdoB.MethodVirtual();

            Console.WriteLine("===== Abstract class, child type instantiate, new method");
            TypeA weirdoC = new ChildTypeC();
            weirdoC.MethodAbstract();
            weirdoC.MethodVirtual();

            Console.WriteLine("===== ChildOfNormalClass class, child type instantiate ");
            ChildOfNormalClass childOfNormalClass = new ChildOfNormalClass();
            childOfNormalClass.MethodToOverride();
            childOfNormalClass.MethodToHide();

            Console.WriteLine("===== Normal class, child type instantiate ");
            NormalClass childOfNormalClass1 = new ChildOfNormalClass();
            childOfNormalClass1.MethodToOverride();
            childOfNormalClass1.MethodToHide();
        }

        private static ulong Factorielle(ulong v)
        {
            return (v > 1) ? (v * Factorielle(v - 1)) : 1;
        }

        public abstract class TypeA
        {
            public abstract void MethodAbstract(); // CANNOT be private, MUST be in a abstract class

            public void MethodNormal() // CANNOT be override, because not marked virtual
            {
                Console.WriteLine("TypeA - MethodNormal");
            }


            public virtual void MethodVirtual()
            {
                Console.WriteLine("TypeA - MethodVirtual");
            }
        }

        public class ChildTypeB : TypeA
        {
            public override void MethodAbstract() // MUST be implemented
            {
                Console.WriteLine("ChildTypeB - MethodAbstract overrided");
            }

            public override void MethodVirtual()
            {
                Console.WriteLine("ChildTypeB - OVERRIDE - MethodVirtual");
            }
        }

        public class ChildTypeC : TypeA
        {
            public override void MethodAbstract() // MUST be implemented
            {
                Console.WriteLine("ChildTypeC - MethodAbstract overrided");
            }

            public new void MethodVirtual()
            {
                Console.WriteLine("ChildTypeC - NEW - MethodVirtual");
            }
        }

        public class NormalClass
        {
            public void MethodToOverride()
            {
                Console.WriteLine("NormalClass - MethodToOverride");

            }

            public void MethodToHide()
            {
                Console.WriteLine("NormalClass - MethodToHide");

            }
        }

        public class ChildOfNormalClass : NormalClass
        {
            public void MethodToOverride()
            {
                Console.WriteLine("ChildOfNormalClass - MethodToOverride");

            }

            public new void MethodToHide()
            {
                Console.WriteLine("ChildOfNormalClass - MethodToHide");
            }

        }

    }
}
