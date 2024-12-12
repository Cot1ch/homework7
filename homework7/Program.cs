using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace homework7
{
    internal class Program
    {
        static void Main()
        {
            Taska();

            Console.WriteLine("Пресс самфинг ту эксит...");
            Console.ReadKey();
        }

        /// <summary>
        /// На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что
        /// решили, что будут получать задачи только в том случае, если это их прямое руководство.
        /// Организовать иерархию конторы, создать несколько примитивых задач.
        /// Задача должна иметь признак кому ее дают = системщикам или
        /// разработчикам или начальству (начальник и зам.начальник отдела), а потом
        /// распределить задачи по сотрудникам. На экране будет следующее: от человека А
        /// даётся задача «название задачи» человек Б. И надо вывести берет человек задачу или нет.
        /// </summary>
        /// <returns>-</returns>
        static void Taska()
        {
            //Блок сотрудников
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
            Person ilya = new Person("Илья", "системщик");
            Person vitya = new Person("Витя", "системщик");
            Person zhenya = new Person("Женя", "системщик");
            //Разрабы
            Person sergey = new Person("Сергей", "Главный разраб");
            Person lyaisan = new Person("Ляйсан", "Зам Сергея");
            //Сотрудники
            Person marat = new Person("Марат", "разраб");
            Person ildar = new Person("Ильдар", "разраб");
            Person dina = new Person("Дина", "разраб");
            Person anton = new Person("Антон", "разраб");

            //Итого
            List<Person> people = new List<Person>()
            {
                timur, rashid, oilham, lucas, orkadiy, volodya, ilshat, ivanych, sergey, lyaisan, ilya, vitya, zhenya, marat, ildar, dina, anton
            };

            //Добавляем подчинённых
            timur.Employers.Add(rashid);
            timur.Employers.Add(oilham);
            rashid.Employers.Add(lucas);
            oilham.Employers.Add(orkadiy);
            orkadiy.Employers.Add(volodya);
            orkadiy.Employers.Add(ilshat);
            volodya.Employers.Add(ilshat);
            ilshat.Employers.Add(ivanych);

            orkadiy.Employers.Add(sergey);
            volodya.Employers.Add(sergey);
            sergey.Employers.Add(lyaisan);

            ilshat.Employers.AddRange(new List<Person>() { ilya, vitya, zhenya });
            ivanych.Employers.AddRange(new List<Person>() { ilya, vitya, zhenya });

            sergey.Employers.AddRange(new List<Person>() { marat, dina, ildar, anton });
            lyaisan.Employers.AddRange(new List<Person>() { marat, dina, ildar, anton });


            Console.WriteLine("Список суперских прогеров ООО 'Какие люди':\n");
            Dictionary<string, Person> persons = new Dictionary<string, Person>();
            foreach (Person person in people)
            {
                persons[person.Name.ToLower()] = person;
                person.PrintInfo();
            }
            // Пара тестовых задач

            Task task1 = new Task("Вызвать сатану", timur, oilham, "Тут по названию понятно");             

            task1.Status = GetStatus(task1, task1.FromWho);

            Console.WriteLine(task1.ToString());

            Task task2 = new Task("Положить сервер КФУ", timur, sergey, "Дедлайн - 23.59, четверг");

            task2.Status = GetStatus(task2 , task2.FromWho);

            Console.WriteLine(task2.ToString());

            //Ввод задачи
            bool flag2 = true;
            do
            {
                Console.WriteLine("\nВыберите действие:\nНовое задание\nВыход");
                string input = Console.ReadLine();

                if (input.ToLower() == "выход")
                {
                    flag2 = false;
                }
                else if (input.ToLower().StartsWith("новое"))
                {
                    Task taska = GetTask(persons);

                    taska.Status = GetStatus(taska, taska.FromWho);

                    Console.WriteLine(taska.ToString());
                }
                else
                {
                    Console.WriteLine("Проверьте коррекность ввода");
                }                
            }
            while (flag2);
        }

        /// <summary>
        /// Получение статуса задачи
        /// </summary>
        /// <returns>Строка string</returns>
        static string GetStatus(Task task, Person person)
        {
            return task.FromWho.Employers.Contains(task.ToWho) ? "Принято" : "Не принято";
        }

        /// <summary>
        /// Ввод данных о сотруднике
        /// </summary>
        /// <returns>Объект типа Person</returns>
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
                    Console.WriteLine("Такого сотрудника нет, проверьте корректность ввода имени");
                }
            }
            while (flag);

            return retPerson;
        }

        /// <summary>
        /// Ввод данных о задаче
        /// </summary>
        /// <returns>Объект типа Task</returns>
        static Task GetTask(Dictionary<string, Person> dict)
        {
            Console.WriteLine("Введите название задачи: ");
            string taskName = Console.ReadLine();

            Console.WriteLine("От кого задача:");
            Person fromWho = GetPerson(dict);
            Console.WriteLine("\t\t<<<<насяльника найден>>>>");

            Console.WriteLine("Кому задача:");
            Person toWho = GetPerson(dict);

            Console.WriteLine("Введите описание задачи: ");
            string disk = Console.ReadLine();

            Task task = new Task(taskName, fromWho, toWho, disk);

            return task;
        }
    }
}
