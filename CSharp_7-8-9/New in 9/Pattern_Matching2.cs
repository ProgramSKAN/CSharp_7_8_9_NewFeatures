using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_9
{
    //and or not is similar to && || ! but the context of usage is different
    public static class Pattern_Matching2
    {
        public static void Run()
        {
            //'is' keyword is not only for Type checking.used for any kind.
            object o=null;
            if(o is not null)
            {

            }

            //'is not' is same as '!=' with additional power. (like Type checks)

            //if(!(o is string))  //OR
            if(o is not string)
            {

            }


            double i = 0.0;
            if(i is 2)
            {

            };

            int temperature=10;
            var feel = temperature switch  //if temperature=100 the RUNTIME EXCEPTION  //it is non exhaustive switch because it didn't handle temperature >20.
            {
                //int t when t<0=>"freezing",  //old way

                < 0 => "freezing",
                >= 0 and < 20 => "tolerable" //'and' keyword
            };
            Console.WriteLine(feel);//tolerable


            int temperature2 = 100;
            var feel2 = temperature2 switch  
            {
                < 0 => "freezing",
                >= 0 and < 20 => "tolerable",
                >=20 =>"warm",    
                //100 => "very hot 100deg"//error   |due to =100 pattern is not rechable
            };
            Console.WriteLine(feel2);//warm


            int temperature3 = 100;
            var feel3 = temperature3 switch
            {
                < 0 => "freezing",
                >= 0 and < 20 => "tolerable",
                >= 20 and not 100 => "warm",
                100 => "very hot 100deg"
            };
            Console.WriteLine(feel3);//very hot 100deg


            int temperature4 = 1000;
            var feel4 = temperature4 switch
            {
                < 0 => "freezing",
                >= 0 and < 20 => "tolerable",
                >= 20 and not 100 => "warm",
                100 or 1000 => "very hot 100deg"
            };
            Console.WriteLine(feel4);//warm         |output is not "very hot 100deg" thought it is 1000


            int temperature5 = 1000;
            var feel5 = temperature5 switch
            {
                < 0 => "freezing",
                >= 0 and < 20 => "tolerable",
                //>= 20 and not 100 and not 1000 => "warm",//OR
                >= 20 and not (100 or 1000) => "warm",
                100 or 1000 => "very hot 100deg"
            };
            Console.WriteLine(feel5);//very hot 100deg 






            Console.WriteLine(isLetter('A'));//True
            Console.WriteLine(isLetterOrSeparator(','));//True
        }


        //'and' has high precedence than 'or'.so firstly expression evaluate ANDs then ORs.
        public static bool isLetter(this char c) =>
            c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

        public static bool isLetterOrSeparator(this char c) =>
            c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or ';' or ',';

    }
}
