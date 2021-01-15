using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_7_8_9.New_in_7._1
{
    public class Infer_Tuple_Names
    {
        public static void Run()
        {
            var user = (name: "Jack", age: 20);
            Console.WriteLine(user);    //("Jack", 20)

            var user1 = (user.age, user.name);
            Console.WriteLine(user1.Item1);
            Console.WriteLine(user1.Item2);
            //or
            Console.WriteLine(user1.age);
            Console.WriteLine(user1.name);

            var months = new[] { "January", "February", "March", "April" };
            var result = months.Select(m => ((m.Length, FirstChar: m[0]))).Where(t => t.Length == 5); //name of item1 in tuple is "Length" eventhough is not mentioned explicity
            Console.WriteLine(string.Join(",",result));


            var now = DateTime.UtcNow;
            var u = (now.Hour, now.Minute);
            (u.Hour, u.Minute) = (11, 12);
            Console.WriteLine((u.Hour, u.Minute));//(11, 12)

            var v = ((u.Hour, u.Minute) = (11, 12));
            Console.WriteLine(v.Hour+","+v.Minute);//11,12 //infered tuple names
        }
    }
}
