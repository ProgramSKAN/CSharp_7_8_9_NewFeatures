using CSharp_7_8_9.New_in_7;
using CSharp_7_8_9.New_in_7._1;
using CSharp_7_8_9.New_in_7._2;
using CSharp_7_8_9.New_in_7._3;
using CSharp_7_8_9.New_in_8;
using CSharp_7_8_9.New_in_9;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp_7_8_9
{
    class Program
    {
        private static string _url = "http://google.com/robots.txt";

        //main return types
        //1.void/int
        //2.string[] args / empty args

        //Async Main
        //1.async Task
        //2.async Task<int>
        static async Task  Main(string[] args)
        {
            //C# 7
            Out_Variables.Run();
            Pattern_Matching.DisplayShape(new Rectangle());
            Tuples.Run();
            Deconstruction.Run();
            Local_Functions.Run();
            Ref_Returns_and_Locals.Run();
            Expression_Bodied_Members.Run();
            Throw_Expressions.Run();
            Generalized_Async_ReturnTypes.Run();
            Literals.Run();


            //AsyncMain.Run().GetAwaiter().GetResult();
            //C# 7.1
            Console.WriteLine(await new HttpClient().GetStringAsync(_url));

            Default_Expressions.Run();

            //Ref_Assemblies.run

            Infer_Tuple_Names.Run();
            Pattern_Matching_With_Generics.Run();

            //C# 7.2
            Leading_Digit_Separators.Run();
            Private_Protected_Access_Modifier.Run();//check OtherProject
            NonTrailing_NamedArguments.Run();
            in_Parameters_refReadonly.Run();

            /*------------TYPES OF MEMORY----------------------
             * MANAGED MEMORY(new operator)
             * small objects <85k (generational part of  managed heap)
             * large objects >85k (large object heap,LOH)
             * Both released by Garbage Collector
             * 
             * UNMANAGED MEMORY
             * allocated on unmanaged heap with Marshal.AllocHGlobal/CoTaskMem
             * released with Marshal.FreeHGlobal/CoTaskMem
             * GC not involved
             * 
             * STACK MEMORY (stackalloc keyword)
             * very fast allocation/deallocation
             * very small (typically <1MB), overallocate and you get StackOverflow/process dies
             * method-scoped: method calls,stack unwinds
             * used less often
             */

            /*Eg: refer to a part of a string without making a copy of substring?
             * can refer to start/end indices or use pointers
             * 
             * 
             * we need a general way of referring to a range of values in memory(for reading,copying,...)
             * that generalization is expressed as Span<T>  .T is the datatype on which you are iterating over
             */


            /*REF STRUCT TYPE
             * a value type that must be stack allocated
             * can never be created on heap as member of another class
             * main motivation to support Span<T>
             * --compiler enfored rules--
             * *cannot box a ref struct(i.e, cannot assign to object,dynamic or interface types)
             * *cannot declare ref struct as a member of class or normal struct
             * *cannot declare local ref struct variables in async methods or synchronous methods that return Task or Task-like types
             * *cannot declare ref struct locals in iterators
             * *cannot declare ref struct vars in lambda expressions ot local functions
             * 
             * rules prevent ref struct from being promoted to managed heap
             */

            //Span_T_Demo.Run();


            //C# 7.3 
            //-performance improvements
            //fixed size buffers    >private fixed char filename[255];

            //ref local variables can be reassigned
            //--ref MyStruct refLocal=ref myStruct;
            //--refLocal=ref someOtherStruct;

            //stackalloc arrays support initializers
            unsafe
            {
                int* pArr1 = stackalloc int[3] { 1, 2, 3 };
                int* pArr2 = stackalloc int[] { 4, 5, 6 };
            }

            //Attributes on backing fields of auto props
            //[field:somecleverattribute]
            //public float SomeProperty { get; set; }


            //"in" method overload resolution tie breaker
            //it allows "in" method overload.the by-value first overload below is preferred to the by-readonly referenced version
            //include "in" modifier to call by-readonly reference version instead
            //static void Foo(X arg);
            //static void Foo(in X arg);


            /*OUT VARIABLE DECLARATIONS can now happen in 
             * 1)Field Initializers
             * 2)Property Initializers
             * 3)Constructor Initializers
             * 4)Query Classes
             */
            //Out_Variable_declaration.Run();

            //Tuples support == and != operators

            //C# 8
            Nullable_Reference_Types.Run();
            Indices_and_Ranges.Run();
            Default_Interface_Members.Run();
            Pattern_Matching1.Run();

            //C# 9
            Record_Types.Run();
            //TOP LEVEL CALLS  //refer to NoMainMethod Project
            Initial_Setters.Run(); //new Keywords>  'init'
            Pattern_Matching2.Run(); //new Keywords>  'and','or','not'
            Target_Typed_New.Run();

            //SOURCE GENERATORS  //C#/Roslyn Meta programming  | alternative nuget Fody,PostSharp,...
            //Souce generators class implements ISourceGenerator and decorate it with [Generator]
            //in C#9, generator spits out text (strings) that get added as source files.
            //alternative> T4 Visual Studio feature

            //prior to C#9, partial methods are always void  and have no params 
            /*In C#9 , Partial methods can have below but implementation of the method is must.
             * 1)Non-Void Return types
             * 2)Out parameters
             * 3)Accessibility keywords
             */
             
            //MODULE INITIALIZERS   //to run code one time when module initializer get called at the beginning of code run
            //https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/module-initializers

        }



    }
}
