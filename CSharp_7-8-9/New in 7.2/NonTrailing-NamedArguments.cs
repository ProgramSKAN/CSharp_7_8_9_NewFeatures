using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._2
{
    public class NonTrailing_NamedArguments
    {
        static void doSomething(int foo,int bar)
        {

        }
        public static void Run()
        {
            doSomething(11, bar: 22);
            doSomething(foo: 11, 22);//named argument can be anywhere.need not be at trailing end only.

            //doSomething(22, foo: 11);//invalid, order cannot be changed

            doSomething(bar: 22, foo: 11);//valid.order can be changed if every argument is named 
        }
    }
}
