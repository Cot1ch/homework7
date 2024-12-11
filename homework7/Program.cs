using System;
using System.Collections.Generic;

namespace homework7
{
    internal class Program
    {
        static void Main()
        {
            Taska(); //раскидать классы по файлам
        }

        static void Taska()
        {
            //Блок сотрудгников

            Person timur = new Person("Тимур", "Генеральный директор");
            Person rashid = new Person("Рашид", "Финансовый директор");
            Person oilham = new Person("О Ильхам", "Директор по автоматизации");
            //Бухгалтерия
            Person lucas = new Person("Лукас", "Главный бухгалтер");
            //ОИТ
            Person orkadiy = new Person("Оркадий", "Начальник отдела информационных систем");
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
                persons[person.Name.ToLower()] = person;
            }

            //Делаем граф со связями сотрудников
            Graph graph = new Graph();
            graph.AddEdge(timur, rashid);
            graph.AddEdge(timur, oilham);

            graph.AddEdge(rashid, lucas);

            graph.AddEdge(oilham, orkadiy);
            graph.AddEdge(orkadiy, volodya);
            graph.AddEdge(orkadiy, ilshat);
            graph.AddEdge(orkadiy, sergey);

            graph.AddEdge(volodya, ilshat);
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

            //Ввод задачи
            Console.WriteLine("Введите название задачи: ");
            string taskName = Console.ReadLine();
            
            Console.WriteLine("От кого задача:");
            Person fromWho = GetPerson(persons);

            Console.WriteLine("Кому задача:");
            Person toWho = GetPerson(persons);

            Console.WriteLine("Введите описание задачи: ");
            string disk = Console.ReadLine();

            Task task = new Task(taskName, fromWho, toWho, disk);

            if (fromWho.Name == fromWho.Name)
            {
                Console.WriteLine("\t\t\t<<<<насяльника найден>>>>");

                string status = graph.Find(fromWho, toWho) ? "Принято" : "Не принято";
                task.Status = status;

                Console.WriteLine(task.ToString());
            }
        }

        static Person GetPerson(Dictionary<string, Person> dict)
        {

            bool flag = true;
            Person retPerson = null; // По идее не должно такого произойти
            do
            {
                string name = Console.ReadLine();
                if (dict.TryGetValue(name.ToLower(), out Person person))
                {
                    retPerson = person;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Такого человека нет, проверьте корректность ввода имени");
                }
            }
            while (flag);

            return retPerson;
        }
    }
}
