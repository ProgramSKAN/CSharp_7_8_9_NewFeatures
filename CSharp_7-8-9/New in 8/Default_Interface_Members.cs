using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_8
{
    //BEHAVIORAL MIXINS
    public interface IHuman
    {
        string Name { get; }
    }
    public static class ExtensionMethods
    {
        public static void Greet(this IHuman human)
        {
            Console.WriteLine($"Hello, I'm {human.Name}");
        }
    }

    //DEFAULT INTERFACE MEMBERS
    public interface IHuman1
    {
        string Name { get; set; }
        public void SayHello()
        {
            Console.WriteLine($"Hello, I'm {Name}");
        }
    }
    public class Human : IHuman1,IFriendlyHuman
    {
        public string Name { get; set; }
    }

    //INTERFACE THAT IMPLEMENTS INTERFACE
    public interface IFriendlyHuman:IHuman1
    {
        public void SayHello()//this is not anyway related to SayHello() inside IHuman1
        {
            Console.WriteLine($"friendly, I'm {Name}");
        }
    }

    public interface IGreetingHuman : IHuman1
    {
        void IHuman1.SayHello() //this is related to SayHello() inside IHuman1. it overrides
        {
            Console.WriteLine($"Greeting, I'm {Name}");
        }
    }

    //DIAMOND INTERFACE
    interface ITalk { void Greet(); }
    interface IAmBritish : ITalk
    {
        void ITalk.Greet() => Console.WriteLine("Good Day!");
    }
    interface IAmAmerican : ITalk
    {
        void ITalk.Greet() => Console.WriteLine("Howdy!");
    }
    //class DualNational : IAmBritish, IAmAmerican  //error >ITalk.Greet() does not have most specific implementation
    //{

    //}





    public class Default_Interface_Members
    {
        public static void Run()
        {
            Human human = new Human() { Name = "Jack" };
            //Human.SayHello();//invalid

            IHuman1 human1 = (IHuman1)new Human() { Name = "Jack" };
            human1.SayHello();

            ((IHuman1)new Human() { Name = "mike" }).SayHello();    //Hello, I'm mike
            ((IFriendlyHuman)new Human() { Name = "mike" }).SayHello();     //friendly, I'm mike
            //((IGreetingHuman)new Human() { Name = "mike" }).SayHello();//overrides IHuman1 ,ie, it makes "Hello, I'm mike" to "Greeting, I'm mike"

        }
    }
}


/*-----------MODIFIERS---------
 * interface syntax extended to accept protected,internal,public,virtual
 * by default, default interface members are virtual unless sealed/private is used
 * interfaces without boides are abstract
 * interfaces can implement interfaces
 */