#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_8
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }//this can be null
        public Person(string first, string last, string middle) => (FirstName, LastName, MiddleName) = (first, last, middle);

        public string FullName => $"{FirstName} {MiddleName[0]} {LastName}";
    }

    public class Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }//assumed to never be null
        public string? MiddleName { get; set; }//nullable   '?'.  it is a source of possible null reference exception
        public Person1(string first, string last, string? middle) => (FirstName, LastName, MiddleName) = (first, last, middle);

        public string FullName => $"{FirstName} {MiddleName[0]} {LastName}";//MiddleName warning of possible null value. warning showed since you explicity told compiler that it is nullable.using '?'

        //int? is a nullable of int
        //string? is not a nullable of string

        //if nullability  is enabled then
        //string?  not same as Nullable<string>

        //string?  is still a string, but we need null checks

        public string FullName1 => $"{FirstName} {MiddleName?[0]} {LastName}";//NULL CHECK
    }

    public class Nullable_Reference_Types
    {
        public static void Run()
        {
            //warning shows only with #nullable enable
            var p =new Person("Jack", "warner", null);//warning >cannot convert null literal to non-nullable ref type
            //srtings are nullable but why warning? > from C#8 onwards, if we use nullability feature "#nullable enable" which starts treating all types as not nullable unless if you explicity tell the compiler.

            Console.WriteLine(p.FullName);//object ref not set to instance of object

            var p1 = new Person("Jack", "warner", null);
            var p2 = new Person("Jack", "warner", "William");

            string GetString() { return null; };
            string? s = GetString();
            char c = s[0];

            if (s != null)
            {
                char c1 = s[0];
            }


            //2ways to stop null checks (warnings)
            //1)keep the variable non-nullable
            //2)write expression with bang(!)

            var fullname=(null as Person).FullName;//warning > possible null reference
            var fullname1=(null as Person)!.FullName;//no warning >  since ! makes compiler not do null check
            //'!' null suppression operator

            var fullname2 = (null as Person)!?.FullName;//does infact perform a null check (?! won't compile)

            Type t = Type.GetType("jack");//null
            Console.WriteLine(t.Name);//no warning
            //Remapping from T to T? has no effect. if t is not nullable then u is not nullable then ? is meaning less
            Type? u = t;
            Console.WriteLine(u.Name);//no warning
        }
    }
}
/*NULLABLE TYPES ARE OFF BY DEFAULT
 * TO turn on
 * 1)#nullable enable     >per file
 * 2)<NullableReferenceTypes>true<NullableReferenceTypes>     >per project
 */

