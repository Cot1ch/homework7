using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;


namespace homework7
{
    internal class Person
    {
        private string _Name;
        private string _Function;

        public Person(string name, string function)
        {
            _Name = name;
            _Function = function;
        }
        public string Name
        { get { return _Name; } 
            set { _Name = value; } }
        public string Function
        { get { return _Function; } 
            set { _Function = value; } }
    }
    internal class Task
    {
        private string _Name;
        private Person _FromWho;
        private Person _ToWho;
        private string _Discription;

        public Task(string name, Person fromWho, Person toWho, string discription)
        {
            _Name = name;
            _FromWho = fromWho;
            _ToWho = toWho;
            _Discription = discription;
        }
    }
    internal class Graph
    {
        private Dictionary<Person, List<Person>> _Graph;
        public Dictionary<Person, List<Person>> graphDict
        {
            get { return _Graph; }
        }

        public Graph()
        {
            _Graph = new Dictionary<Person, List<Person>>();
        }


        public void AddEdge(Person start, Person end)
        {
            if (!graphDict.ContainsKey(start))
                graphDict[start] = new List<Person>();
            graphDict[start].Add(end);
        }
        public override string ToString()
        {
            string result = "";
            foreach (var pair in graphDict)
            {
                result += $"{pair.Key.Name}-->\n";
                foreach (Person neighbor in pair.Value)
                {
                    if (neighbor != null)
                    {
                        result += $"{neighbor.Name, -8}| {neighbor.Function}\n";
                    }
                }
                result += "\n";
            }
            return result;
        }

        public bool Find(Person p1, Person p2)
        {
            if (graphDict.ContainsKey(p1))
            {
                foreach (var p in graphDict[p1])
                {
                    if (p.Name == p2.Name)
                    {
                        Console.WriteLine("Победа");
                        return true;
                    }
                    else
                    {
                        if (Find(p, p2))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
