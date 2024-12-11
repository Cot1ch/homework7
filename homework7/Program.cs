using System;
using System.Collections.Generic;

namespace homework7
{
    internal class Program
    {
        static void Main()
        {
            Taska(); //добавить try-ввод имен, ToLower, раскидать классы по файлам
        }

        static void Taska()
        {
            Person timur = new Person("Тимур", "Ген дир");
            Person rashid = new Person("Рашид", "Фин дир");
            Person oilham = new Person("О Ильхам", "Авто дир");
            //Бухгалтерия
            Person lucas = new Person("Лукас", "Главный бух");
            //ОИТ
            Person orkadiy = new Person("Оркадий", "Начальник инф систем");
            Person volodya = new Person("Володя", "Зам Оркадия");
            //Системщики
            Person ilshat = new Person("Ильшат", "Главный системщик");
            Person ivanych = new Person("Иваныч", "Зам Ильшата");
            //Сотрудники
            List<Person> engineers = new List<Person>()
            {
                new Person("Илья", "системщик"),
                new Person("Витя", "системщик"),
                new Person("Женя", "системщик")
            };
            //Разрабы
            Person sergey = new Person("Сергей", "Главный разраб");
            Person lyaisan = new Person("Ляйсан", "Зам Сергея");
            //Сотрудники
            List<Person> developers = new List<Person>()
            {
                new Person("Марат", "разраб"),
                new Person("Ильдар", "разраб"),
                new Person("Дина", "разраб"),
                new Person("Антон", "разраб")
            };

            List<Person> people = new List<Person>()
            {
                timur, rashid, oilham, lucas, orkadiy, volodya, ilshat, ivanych, sergey, lyaisan
            };
            people.AddRange(engineers);
            people.AddRange(developers);

            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            foreach (Person person in people)
            {
                persons[person.Name] = person;
            }

            Graph graph = new Graph();
            graph.AddEdge(timur, rashid);
            graph.AddEdge(timur, oilham);
            graph.AddEdge(rashid, lucas);
            graph.AddEdge(oilham, orkadiy);
            graph.AddEdge(orkadiy, volodya);
            graph.AddEdge(orkadiy, ilshat);
            graph.AddEdge(volodya, ilshat);
            graph.AddEdge(orkadiy, sergey);
            graph.AddEdge(volodya, sergey);
            graph.AddEdge(ilshat, ivanych);
            graph.AddEdge(sergey, lyaisan);

            for (int i = 0; i < developers.Count; i++)
            {
                graph.AddEdge(sergey, developers[i]);
                graph.AddEdge(lyaisan, developers[i]);
            }

            for (int i = 0; i < engineers.Count; i++)
            {
                graph.AddEdge(ilshat, engineers[i]);
                graph.AddEdge(ivanych, engineers[i]);
            }

            Console.WriteLine(graph.ToString());



            Console.WriteLine("От кого задача:");
            string namefrom = Console.ReadLine();

            if (persons.TryGetValue(namefrom, out var personfrom))
                namefrom = personfrom.Name;

            Console.WriteLine("Кому задача:");
            string nameto = Console.ReadLine();
            if (persons.TryGetValue(nameto, out var personto))
                nameto = personto.Name;

            Person employee = persons[namefrom];
            Person employee2 = persons[nameto];




            if (employee.Name == namefrom)
            {
                Console.WriteLine("насяльника найден");

                if (graph.Find(employee, employee2))
                {
                    Console.WriteLine("Принято");
                }
                else
                {
                    Console.WriteLine("Не принято");
                }
            }

        }
    }
}
