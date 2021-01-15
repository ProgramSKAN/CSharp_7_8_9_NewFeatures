using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._2
{
    public class Leading_Digit_Separators
    {
        public static void Run()
        {
            var x = 0b_1010_1111;  //_ is allowed after 0b
            var y = 0x_BAAD_F00D;

            //var z = _1010_0001;   //invalid

        }
    }
}
