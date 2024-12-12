using System;
using System.Collections.Generic;

namespace homework7
{
    internal class Person
    {
        private string _Name;
        private string _Function;
        private List<Person> _Employers;

        public Person(string name, string function)
        {
            _Name = name;
            _Function = function;
            _Employers = new List<Person>();
        }
        
        public string Name
        { 
            get { return _Name; } 
            set { _Name = value; } 
        }
        public string Function
        { 
            get { return _Function; } 
            set { _Function = value; } 
        }
        public List<Person> Employers 
        { 
            get { return _Employers; } 
            set { _Employers = value; } 
        }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name, -7} --> {Function}");
            string info = String.Empty;
            if (Employers != null)
            {
                foreach (Person person in Employers)
                {
                    info += $"{person.Name, -8} | {person.Function}\n";
                }
            }
            Console.WriteLine(info);
        }
    }
}
