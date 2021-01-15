using System;
using System.Reflection;
using System.Threading.Tasks;



Console.WriteLine("Hello World!");
Foo();
void Foo()
{
    Console.WriteLine("Foo");
}
Foo();

Console.WriteLine(args[0]);//HelloArg
Console.WriteLine(args.Length);//1

//await is also valid
await Task.CompletedTask;


//Method Name is not Demo
var method = MethodBase.GetCurrentMethod();
Console.WriteLine(method.DeclaringType.Namespace);//null
Console.WriteLine(method.DeclaringType.Name);//<< Main >$> d__0     not "Demo"
Console.WriteLine(method.Name);//MoveNext







//return works
return 1;

class Person
{

};

//Foo(); //invalid TOP LEVEL STATEMENTS must be before Types (ex: Person)


//behind the scenes, there will a class with Main method inside with all the TOP LEVEL STATEMENTS go.