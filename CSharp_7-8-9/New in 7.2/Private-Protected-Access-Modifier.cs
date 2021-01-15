using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._2
{
    public class Base
    {
        private int a;
        protected internal int b;//1)derived classes (ANY assembly).
                                //2)classes of same assembly.

        private protected int c; //1)containing class
                                   //2)derived classes (current assembly)
    }
    public class Private_Protected_Access_Modifier
    {
        public static void Run()
        {
            Base b = new Base();

        }
    }

    public class Derived : Base
    {
        public Derived()
        {
            b = 111;
            c = 222;
            //c works, since it is in same assembly
            //but it wont work in other assembly
        }
    }
}
