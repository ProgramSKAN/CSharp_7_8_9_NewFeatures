using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7._1
{
    public class Ref_Assemblies
    {
        private int id;
        protected string Name { get; set; }
        public void SayHello() => Console.WriteLine("Hi" + Name);
    }

    //compile assembiles
    //cmd> csc Ref_Assemblies.cs /out

    //to output ref assembly instead of implementation assembly
    //cmd> csc Ref_Assemblies.cs /refout:Demo.dll
    //cmd> csc Ref_Assemblies.cs /refonly
}
