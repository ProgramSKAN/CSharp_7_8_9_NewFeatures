using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_9
{
    public class Person1
    {
        public readonly int SecretKey;
        public Person1(int sKey)
        {
            this.SecretKey = sKey;
        }
        void ChangeIt()
        {
            //SecretKey = 0;//Readonly field can't be changed.
        }
    }

    public class Person2
    {
        public int SecretKey { get; init; }

        private readonly string lastName;

        public string FirstName;

        public Person2() { }
        public Person2(int sKey)
        {
            SecretKey = sKey;
            //this[0] = "JACK";  //instead of constructor it can be initialized in 'INIT' also
        }
        public void ChangeIt(int sKey)
        {
           // SecretKey = sKey;//Init only property or indexer can only be assigned in an object initializer.
        }

        public string LastName
        {
            get => lastName;
            init => lastName = value ?? throw new ArgumentNullException(nameof(lastName));
            //by default readonly 'lastName' is accessible only inside constructor. Now it can be accessible inside INITIALIZER
        }

        //INDEXER
        public string this[int i]
        {
            get { return i > 0 ? LastName : FirstName; }
            init
            {
                if (i > 0) LastName = value;
                else FirstName = value;
            }
        }

    }

    public class Initial_Setters
    {
        public static void Run()
        {
            var p = new Person2() { SecretKey = 12345 };
            Console.WriteLine(p.SecretKey);//12345
            Console.WriteLine(p.FirstName);//null
            Console.WriteLine(p.LastName);//null


            var p1 = new Person2() { SecretKey = 12345,FirstName="Jack",LastName="Warner" };
            Console.WriteLine(p1.SecretKey + p1.FirstName +     p1.LastName); //12345 Jack Warner
            Console.WriteLine(p1[0]);//Jack
            Console.WriteLine(p1[1]);//Warner

            var p2 = new Person2() ;
            //p2[0] = "sdfs";
            
        }
    }
}
