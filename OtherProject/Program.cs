using CSharp_7_8_9.New_in_7._2;
using System;

namespace OtherProject
{
    class foo : Base
    {
        public foo()
        {
            var id=this.b;//b is accessible since it is protected 
            //this.c;//c is not accessible since it is private protected 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Derived d = new Derived();
            //d.a;    //invalid
            //d.b;    //invalid
            //d.c;    //invalid
        }
    }
}
