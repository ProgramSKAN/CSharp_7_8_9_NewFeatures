using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Person
    {
        private int id;
        private static readonly Dictionary<int, string> names = new Dictionary<int, string>();
        public Person(int id, string name) => names.Add(id, name);
        ~Person() => names.Remove(id);//destructor

        public string Name { 
            get=>names[id]; 
            set=>names[id]=value; 
        }
    }
    public class Expression_Bodied_Members
    {
        public static void Run()
        {

        }
    }
}
