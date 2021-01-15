using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Literals
    {
        public static void Run()
        {
            //for readablity _'s can be added. _ is ignored by the compiler;
            int a = 123_321_245;
            int b = 123__321__________1234;
            //int c = 1234___;//invalid

            long hexadecimal = 0XAB_BC_D1234EF;
            var binary = 0b1110_0101_1111;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(hexadecimal);
            Console.WriteLine(binary);
        }
    }
}
