using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._1
{
    public class Animal { };
    public class Lion : Animal { };
    public class Pattern_Matching_With_Generics
    {
        public static void Cook<T>(T animal) where T : Animal
        {
            //if ((object)animal is Lion lion)  //cast is not needed
            if (animal is Lion lion)
            {

            }

            switch(animal)
            {
                case Lion ln:
                    break;
            }
        }
        public static void Run()
        {

        }
    }
}
