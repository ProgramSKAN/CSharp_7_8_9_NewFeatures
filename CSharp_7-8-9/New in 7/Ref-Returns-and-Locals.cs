using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Ref_Returns_and_Locals
    {
        public static void Run()
        {
            int[] numbers = { 1, 2, 3 };
            ref int refToSecond = ref numbers[1];
            var valueOfSecond = refToSecond;

            //refToSecond = ref numbers[0];//invalid

            refToSecond = 1234;
            Console.WriteLine(string.Join(",",numbers));

            Array.Resize(ref numbers, 1);
            Console.WriteLine($"second:{refToSecond}, array size is {numbers.Length}");
            refToSecond = 4321;
            Console.WriteLine($"second:{refToSecond}, array size is {numbers.Length}");
            //numbers.SetValue("4321", 1);//invalid since array size is 1

            var numberList = new List<int> { 1, 2, 3 };
            //ref int second = ref numberList[1];//invalid as ref is not applicable to list


            int[] moreNumbers = { 10, 20, 30 };
            Console.WriteLine(string.Join(",",moreNumbers));
            ref int refToTwenty =ref Find(moreNumbers, 20);
            refToTwenty = 1000;
            Console.WriteLine(string.Join(",", moreNumbers));

            //C#-7
            Find(moreNumbers, 30) = 2000;
            Console.WriteLine(string.Join(",", moreNumbers));


            int a = 1, b = 2;
            ref int minValue =ref Min(ref a, ref b);

        }

        //ref returned from function
        static ref int Find(int[] numbers,int value)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == value)
                    return ref numbers[i];
            }

            //what ref to return if value not found?
            //return -1;//invalid
            int fail = -1;
            //return ref fail;//invalid

            throw new ArgumentException("not found");
        }

        static ref int Min(ref int x,ref int y)
        {
            //return x < y ? x : y;//invalid
            //return x < y ? (ref x) : (ref y);//invalid
            //return ref (x < y ? x : y);//invalid

            if (x < y) return ref x;
            return ref y;
        }
    }
}
