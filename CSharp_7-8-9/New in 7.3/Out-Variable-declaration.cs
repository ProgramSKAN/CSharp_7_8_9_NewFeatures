using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._3
{
    public class B
    {
        public B(int i,out int j)
        {
            j = i;
        }
    }
    public class Out_Variable_declaration:B
    {
        public Out_Variable_declaration(int i):base(i,out var j)
        {
            Console.WriteLine($"j={j}");
        }

        public static void Run()
        {
            new Out_Variable_declaration(5);
        }
    }
}
