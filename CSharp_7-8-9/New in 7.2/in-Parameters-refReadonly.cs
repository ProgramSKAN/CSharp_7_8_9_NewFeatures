using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._2
{
    struct Point// Structs are used for lightweight objects such as Color, Rectangle, Point etc.struct is a value type.useful if you have data that is not intended to be modified after creation of struct.
    {
        public double X, Y;
        public Point(double x,double y)
        {
            X = x;
            Y = y;
        }

        public static Point Origin = new Point();


        //prefer
        private static Point _origin = new Point();
        public static ref readonly Point Origin1 => ref _origin;


        public void Reset()
        {
            X = Y = 0;
        }
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
    //Point struct has 2 doubles.
    //double is 8 byte. 2 doubles> 16bytes
    //if we pass Point to a method.it means of passing 16bytes

    //same as pointers in C++.Instead os passing in the entire structure, 
    //it should be possible to designate an argument of a method where 
    //structure is passed by reference instead of by value

    //before C#7.2, if struct is passed to a method , it make a full copy of the entire memory.

    //in keyword says> Point structure is passed in by reference instead of by value.MEMORY SAVING
    //simply "in" is readonly ref struct keyword
    public class in_Parameters_refReadonly
    {
        //double MeasureDistance(Point p1,Point p2)   >this means passing 2doubles>16bytes.since struct is a value type.
        double MeasureDistance(in Point p1,in Point p2) //take value type struct as reference type(ie:memory address (32/64bit)).MEMORY SAVING
        {
            //"in" keyword makes the stucture readonly.so,cannot modify.
            //p1 = new Point(); //invalid
            //changeMe(ref p2); //invalid
            p1.Reset(); //valid eventhough it mutates X,Y to 0, but it makes a copy.so dx,dy remains unchanged. 

            var dx = p1.X - p2.X;
            var dy = p1.Y - p2.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        //INVALID> cannot have overloads with just difference of "in"
        //double MeasureDistance(in Point p1, in Point p2)
        //{
        //    return 0.0;
        //}

        public in_Parameters_refReadonly()
        {
            var p1 = new Point(1, 1);
            var p2 = new Point(4, 5);
            var distance = MeasureDistance(p1, p2);
            Console.WriteLine($"Distance between {p1} and {p2} is {distance}");

            var distanceFromOrigin = MeasureDistance(p1, new Point());
            Console.WriteLine($"Distance From Origin to {p1} is {distanceFromOrigin}");

            var distanceFromOrigin1 = MeasureDistance(p1,Point.Origin);//Point.Origin is again a pass by value which makes a new copy of Point Memory.
            //remedy: use ref readonly like below

            //prefer
            var distanceFromOrigin2 = MeasureDistance(p1, Point.Origin1);//Origin1 is a ref not value

            Point copyOfOrigin = Point.Origin1;//it is by-value copy of memory since there is not ref keyword

            //ref var messWithOrigin = ref Point.Origin1;//invalid since Point.Origin1 is readonly

            ref readonly var originRef = ref Point.Origin1;
            //originRef.X++;//invalid since originRef is readonly
        }

        public static void Run()
        {
            new in_Parameters_refReadonly();
        }

        void changeMe(ref Point p)
        {
            p.X++;
        }
    }
}
