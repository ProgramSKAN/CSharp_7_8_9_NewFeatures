using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._1
{
    public class Default_Expressions
    {
        public static void Run()
        {
            int a = default(int);//0
            bool b = default(bool);//false
            DateTime c = default(DateTime);//1/1/0001 12:00:00 AM
            string d = default(string);//null, since string is reference type

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);


            //C# 7.1
            int e = default;    //0
            const int f = default;  //0
            //const int? g = default;   //invalid const nullable
            int? h = default;   //null
            Console.WriteLine(h==null);     //true

            var i = new[] { default, 25, default };     //since 25 is int , defaults set to 0
            //var j = new[] { default, default };   //invalid since it donno what type to infer

            string k = default;     //null
            if (k == default)
            {

            }

            var l = a > 0 ? default : 1.5;  //default is 0.0 sice 1.5 is double

        }

        public DateTime GetTimeStamps(List<int> items = default(List<int>))// list is ref type, so default(List<int>)=null
        {
            return default; //1/1/0001 12:00:00 AM
        }
        //or
        public DateTime GetTimeStamps1(List<int> items = default)// list is ref type, so default(List<int>)=null
        {
            return default; //1/1/0001 12:00:00 AM
        }
    }
}
