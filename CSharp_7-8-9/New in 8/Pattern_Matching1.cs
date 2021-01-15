using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_8
{
    struct PhoneNumber
    {
        public int? code, Number;
    }
    struct Persons
    {
        public string Name;
        public PhoneNumber PhoneNumber;
    }
    public class Pattern_Matching1
    {
        public static void Run()
        {
            var phoneNumber = new PhoneNumber() { code=44};
            var origin = phoneNumber switch // switch non exhaustive as it can't hadle null/not found
            {
                { Number: 112 } => "Emergency",
                { code: 44 } => "UK"
            };
            Console.WriteLine(origin);  //UK

            var phoneNumber1 = new PhoneNumber() { Number=500 };
            var origin1 = phoneNumber1 switch
            {
                { Number: 112 } => "Emergency",
                { code: 44 } => "UK",
                { } => "Unknown"
            };
            Console.WriteLine(origin1);  //Unknown


            var phoneNumber2 = new PhoneNumber() { Number = null };
            var origin2 = phoneNumber2 switch
            {
                { Number: 112 } => "Emergency",
                { code: 44 } => "UK",
                _ =>"Missing"
            };
            Console.WriteLine(origin2);  //Missing



            //------RECURSIVE PATTERN------
            var person = new Persons() { Name = "mike", PhoneNumber = new PhoneNumber() { code = 465 } };
            var personOrigin = person switch
            {
                { Name: "Jack" } => "London",
                { PhoneNumber: { code: 46 } } => "Sweden",
                { Name: var name } => $"no idea where {name} lives"
            };
            Console.WriteLine(personOrigin);//no idea where mike lives"


            //SWITCH BASED VALIDATION
            //var person1 =  new Persons() { Name = "mike", PhoneNumber = new PhoneNumber() { code = 465 } };
            //var error = person1 switch
            //{
            //    null=>"Object Missing",
            //    { PhoneNumber:null}=>"Phone Number is missing entirely",
            //    { PhoneNumber: { Number:0} }=>"Actual number missing",
            //    { PhoneNumber: { code:var code} } when code<0=>"code can't be negative",
            //    { }=>null//no error
            //};
            //if (error != null)
            //    throw new ArgumentException(error);


            //DECONSTRUCTION
            //Shape shape = new Rectangle() { X = 0, Y = 0 };
            //var type = shape switch
            //{
            //    Rectangle((0, 0), 0, 0) => "Point at origin",
            //    Circle((0, 0), _) => "Circle at origin",
            //    Rectangle(_, var w, var h) when w == h => "Square",
            //    Rectangle((var x, var y), var w, var h) => $"A {w}*{h} rectangle at ({x},{y})",
            //    _ => "Somethin else"
            //};
        }
    }









    public class Shape
    {
        public int X, Y;
    }
    public class Rectangle1 : Shape
    {
        public int Width, Height;
    }

    public class Circle1 : Shape
    {

    }
}
