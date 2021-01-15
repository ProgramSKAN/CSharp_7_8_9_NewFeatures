using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Tuples
    {
        static Tuple<double,double> SumAndProduct(double a, double b)
        {
            return Tuple.Create(a + b, a * b);
        }

        static (double,double) NewSumAndProduct(double a, double b)
        {
            return (a + b, a * b);
        }
        static (double Sum, double Product) New2SumAndProduct(double a, double b)
        {
            return (a + b, a * b);
        }
        public static void Run()
        {
            var sp = SumAndProduct(2, 5);
            Console.WriteLine($"Sum: {sp.Item1}, Product:{sp.Item2}");

            var sp1 = NewSumAndProduct(2, 5);
            Console.WriteLine($"Sum: {sp1.Item1}, Product:{sp1.Item2}");

            //value tuple
            var sp2 = New2SumAndProduct(2, 5);
            Console.WriteLine($"Sum: {sp2.Sum}, Product:{sp2.Product}");
            Console.WriteLine(sp2.GetType());

            ValueTuple<double, double> vt = sp2;
            Console.WriteLine($"Sum: {vt.Item1}, Product:{vt.Item2}");

            var (Sum, Product) = SumAndProduct(1, 2);
            (double Sum1, double Product1) = SumAndProduct(1, 2);

            double s, p;
            (s,p)= SumAndProduct(1, 2);

            var user = (name: "Skan", age: 20);
            Console.WriteLine(user);
            Console.WriteLine($"Name: {user.name}, Age: {user.age}");

            var snp = new Func<double, double, (double, double)>((a, b) => (Sum: a + b, Product: a * b));
            var result= snp(1, 2);
            Console.WriteLine($"Sum: {result.Item1}, Product:{result.Item2}");

            var snp2 = new Func<double, double, (double Sum, double Product)>((a, b) => (a + b, a * b));
            var result2 = snp2(1, 2);
            Console.WriteLine($"Sum: {result2.Item1}, Product:{result2.Item2}");
            Console.WriteLine($"Sum: {result2.Sum}, Product:{result2.Product}");


        }
    }
}
