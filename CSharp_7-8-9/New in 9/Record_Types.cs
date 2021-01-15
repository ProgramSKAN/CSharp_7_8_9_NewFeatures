using System;
using System.Collections.Generic;
using System.Text;
namespace System.Runtime.CompilerServices
{
    public class IsExternalInit { }
}

namespace CSharp_7_8_9.New_in_9
{
    public record Address
    {
        public int HouseNumber { get; }
        public string Street { get; }
        public Address() { }
        public Address(int houseNumber, string street)
        {
            HouseNumber = houseNumber;
            Street = street;
        }
    };

    public record Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    };


    public record Color
    {
        public string Name;
        public bool Metallic;
        public Color() { }
        public Color(string name,bool metallic)
        {
            Name = name;
            Metallic = metallic;
        }
    }
    public record Car
    {
        public Color Color { get; set; }
        public string Engine { get; set; }
    }

    public record Point(int X,int Y);//for point example like this better user struct instead. as record turns into class not struct.
    public class Record_Types
    {
        public static void Run()
        {
            var t = typeof(Person);
            foreach(var m in t.GetMembers())
            {
                Console.WriteLine($"- {m.Name}");
                    /*  - get_Name
                        - set_Name
                        - get_Age
                        - set_Age
                        - ToString
                        - op_Inequality
                        - op_Equality
                        - GetHashCode
                        - Equals
                        - Equals
                        -  < Clone >$
                        - GetType
                        - .ctor
                        - Name
                        - Age*/
            }

            var p = new Person { Name = "Jack", Age = 20 };
            Console.WriteLine(p);
            var p2 = new Person { Name = "Jack", Age = 20 };
            Console.WriteLine(p == p2);//True,  because it is comparision by value not by reference

            p.Address = new(123, "London Wall st");
            p2.Address = new(1234, "London Wall st");
            Console.WriteLine(p == p2);//False,  the structural comparision is recursive

            Console.WriteLine(typeof(Person).GetInterfaces()[0].Name);  //IEquatable`1  >the only interface recor type actually supports

            //POSITIONAL RECORDS
            var origin = new Point(0, 0);
            var (x, y) = origin;
            Console.WriteLine((x, y));//(0, 0)

            var p3 = new Point(2, 4);
            Console.WriteLine(p3.GetHashCode());//801273664

            //WITH EXPRESSIONS
            Car car = new() { Color = new() {Name= "White",Metallic=false }, Engine = "V6" };
            Car upgradedCar = car with { Engine = "V8" };//car gets cloned(shallow copy, not deep copy) and modified
            //shallow copy >the reference to car is copied as they are.which can lead to unpredicted result.
            upgradedCar.Color.Metallic = true;

            Console.WriteLine("car: "+car);//car: Car { Color = Color { Name = White, Metallic = True }, Engine = V6 }
            Console.WriteLine("upgradedCar: "+ upgradedCar);//upgradedCar: Car { Color = Color { Name = White, Metallic = True }, Engine = V8 }
            //Observation: Metallic="True" for both car and upgradedCar even though only upgradedCar metallic made to True;
            //because with calls Clone()=ShallowCopy where reference to the Color get copied
            //Remedy: make everything immutable/new object 

        }
    }
}
