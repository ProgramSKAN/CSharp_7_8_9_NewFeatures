using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class EquationSolver
    {
        public static Tuple<double,double> SolveQuadratic(double a,double b,double c)
        {
            //Local Function 
            var calculateDiscriminant = new Func<double, double, double, double>((aa, bb, cc) => bb * bb - 4 * aa * cc);
            //OR
            double calculateDiscriminant1(double aa, double bb, double cc)
            {
                return bb * bb - 4 * aa * cc;
            };
            //OR
            double calculateDiscriminant2() { return b * b - 4 * a * c; }
            //OR
            double calculateDiscriminant3()=> b * b - 4 * a * c;

            var disc = calculateDiscriminant1(a, b, c);
            var rootDisc = Math.Sqrt(disc);
            return Tuple.Create((-b - rootDisc) / (2 * a), (-b + rootDisc) / (2 * a));


            //local function can be anywhere accessible
            double calculateDiscriminant4() => b * b - 4 * a * c;
        }
    }
    public class Local_Functions
    {
        public static void Run()
        {
            var result = EquationSolver.SolveQuadratic(1, 10,16);
            Console.WriteLine("Quadratic: "+ result);
        }
    }
}
