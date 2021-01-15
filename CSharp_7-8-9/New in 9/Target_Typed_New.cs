using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_9
{
    public class Person3
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person3(){}
        public Person3(string name)
        {
            Name = name;
        }
    }
    public class Target_Typed_New
    {
        public static void Run()
        {
            Person3 p = new Person3() { Name = "Jack" };
            //OR
            var p1 = new Person3() { Name = "Jack" };
            //OR
            Person3 p2 = new() { Name = "Jack" };
            //OR
            Person3 p3;
            //...
            p3 = new() { Name = "Jack", Age = 20 };
            //OR
            Person3 p4 = new("Jack");

            //var p = new("Jack"); //invalid

            UsePerson(new Person3("Jack"));
            //OR
            UsePerson(new("Jack"));
        }

        public static void UsePerson(Person3 p)
        {
            //....
        }

        public static Person3 MakePerson(string name,int age)
        {
            return new() { Name = name, Age = age }; //Person3 Type auto infered
            //OR
            return new(name) { Age = age };
        }
    }
}
