using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Deconstruction
    {
        public static void Run()
        {
            var user = (name: "Skan", age: 20);
            var (name, age) = user;
            Console.WriteLine(name,age);


            var point = new Point();
            var (x,y) = point;
            Console.WriteLine($"Point: {x},{y}");

            var (xOnly, _) = point;
            Console.WriteLine($"x Only Point: {x}");
        }
    }

    public class Point
    {
        public int X,Y;

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }
}
