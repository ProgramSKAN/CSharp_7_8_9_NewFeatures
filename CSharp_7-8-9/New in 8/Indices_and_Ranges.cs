using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_8
{
    public class Indices_and_Ranges
    {
        public static void Run()
        {
            //INDICES
            Index i0 = 2;//implicit conversion
            Index i1 = new Index(value: 0, fromEnd: false);
            var i2 = ^0;//Index(0,true)
                        //-1 is not last

            var items = new[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(string.Join(",",items)); //1,2,3,4,5
            items[^2] = 42;
            Console.WriteLine(string.Join(",", items));//1,2,3,42,5


            //RANGES
            Console.WriteLine(string.Join(",", items[0..4]));// 1,2,3,42
            Console.WriteLine(string.Join(",", items[0..^0]));// 1,2,3,42,5
            Console.WriteLine(string.Join(",", items[0..^2]));// 1,2,3

            //Console.WriteLine(string.Join(",", items[4..0]));//invalid  >Argument out of range


            Index x1 = 0;
            Index x2 = 2;
            var a = x1..x2; //Range(x1,x2)
            var b = x1..;   //Range(x1,new Index(0,true))
            var c = ..x2;   //Range(new Index(0,false),x2)
            var d = 0..2;
            //var e = 1..2..100;//invalid
            var f = ..;
            Range.StartAt(0);
            Range.EndAt(2);
            Console.WriteLine("---------------------");
            Console.WriteLine(string.Join(",", items[a]));  //1,2
            Console.WriteLine(string.Join(",", items[b]));  //1,2,3,42,5
            Console.WriteLine(string.Join(",", items[c]));  //1,2
            Console.WriteLine(string.Join(",", items[d]));  //1,2
            Console.WriteLine(string.Join(",", items[f]));  //1,2,3,42,5
            Console.WriteLine(string.Join(",", items[Range.StartAt(0)]));   //1,2,3,42,5
            Console.WriteLine(string.Join(",", items[Range.EndAt(2)])); //1,2

            //Array Slices yield copies
            var stuff = items[..2];//creates a copy
            Console.WriteLine(string.Join(",", stuff)); //1,2

            //strings yield substrings
            Console.WriteLine("foo"[..^1]); //fo

            string str = "hello, world";
            string worldString = str.Substring(startIndex: 7, length: 5); // Allocates
            ReadOnlySpan<char> worldSpan =str.AsSpan().Slice(start: 7, length: 5); // No allocation
            Console.WriteLine(worldSpan.ToString());//world

            //Custom types can define their own indexers
            //public int[] this[Range, Range]
            //{
            //    get >...
            //}
        }
    }
}
