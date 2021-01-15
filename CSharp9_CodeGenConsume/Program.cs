using System;

namespace CSharp9_CodeGenConsume
{
    //add reference Project : CSharp9_CodeGenerator
    //make ReferenceOutputAssembly: No    |in dependencies>projects>CSharp9_CodeGenerator>properties
    //in csproj> OutputItemType="Analyzer"   |this adds CSharp9_CodeGenerator file in dependencies>Analyzers
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Foo().Bar);//bar  | it compiles and run though Foo is not defined
        }
    }
}
 