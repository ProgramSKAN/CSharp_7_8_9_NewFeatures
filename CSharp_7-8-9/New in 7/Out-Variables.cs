using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Out_Variables
    {
        public static void Run()
        {
            DateTime dt;
            if(DateTime.TryParse("01/01/2021",out dt))
            {
                Console.WriteLine(dt);
            }

            if(DateTime.TryParse("01/02/2021", out DateTime dt2))
            {
                Console.WriteLine(dt2);
            }
            Console.WriteLine(dt2);

            int.TryParse("abcd", out int i);
            Console.WriteLine(i);//0
        }
    }
}
