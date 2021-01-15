using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Throw_Expressions
    {
        public string Name { get; set; }
        public Throw_Expressions(string name)
        {
            Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
        }
        
        int GetValue(int n)
        {
            return n > 0 ? n + 1 : throw new Exception();
        }

        public static void Run()
        {
            int value = -1;
            try
            {
                var x = new Throw_Expressions("");
                value = x.GetValue(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("value :"+ value);
            }
        }
    }
}
