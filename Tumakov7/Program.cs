﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov7
{
    internal class Program
    {
        static void Main()
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4(); //Написать само задание
            //Task5();
            //Task6();

            Console.WriteLine("Пресс самфинг то эксит...");
            Console.ReadKey();
        }
        static void Task1()
        {
            Console.WriteLine("Упражнение 8.1\n");
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount();

            Console.WriteLine("Введите данные вашего аккаунта");
            account1 = InputAcc();

            Console.WriteLine("Введите данные второго аккаунта");
            account2 = InputAcc();

            
            bool flag = true;
            do
            {
                Console.WriteLine("Введите сумму перевода");
                decimal summ = EnterDecimal();

                if (account1.moneyTransfer(account2, summ))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("НЕДОСТАТОЧНО СРЕДСТВ, попробуйте снова");
                }
            }
            while (flag);
            Console.WriteLine("Перевод выполнен, ждите зачисления денег на счёт");
        }

        static BankAccount InputAcc()
        {
            BankAccount acc = new BankAccount();

            Console.WriteLine("Выберите тип: 1 - Текущий, 2 - Сберегательный");
            acc.account = EnterAccType();

            Console.WriteLine("Введите баланс");
            acc.balance = EnterDecimal();

            return acc;
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к неотрицательному числу. Ввод продолжается до тех пор, 
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>Число типа decimal</returns>
        static decimal EnterDecimal()
        {
            bool flag = true;
            decimal number;
            do
            {
                bool isNumber = decimal.TryParse(Console.ReadLine(), out number);
                if (isNumber && number >= 0)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести неотрицательное целое число");
                }
            }
            while (flag);

            return number;
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к 0 либо 1. Ввод продолжается до тех пор, 
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>Число типа byte</returns>
        static BankAccount.Account EnterAccType()
        {
            bool flag = true;
            byte number;
            do
            {
                bool isNumber = byte.TryParse(Console.ReadLine(), out number);
                if (isNumber && number <= 2 && number >= 1)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести 1 либо 2");
                }
            }
            while (flag);

            switch (number)
            {
                case 1:
                    return BankAccount.Account.Текущий;
                default: // == 2
                    return BankAccount.Account.Сберегательный;
            }
        }


        static void Task2()
        {
            Console.WriteLine("Упражнение 8.2\n");

            Console.WriteLine("Введите строку");
            string s = Console.ReadLine();
            Console.WriteLine(Reverse(s));
        }
        static string Reverse(string str)
        {
            string retStr = String.Empty;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                retStr += str[i];
            }
            
            return retStr;
        }
        static void Task3()
        {
            Console.WriteLine("Упражнение 8.3\n");

            Console.WriteLine("Введите название файла (1.txt умолчанию)");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name))
            {
                name = "1.txt";
            }
            string filePath = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\{name}";
            if (File.Exists(filePath))
            {
                string readContent = File.ReadAllText(filePath);

                File.WriteAllText($"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\2.txt", GetUpper(readContent));

                Console.WriteLine("Выходные данные записаны в файл resourses/2.txt");
            }
            else
            {
                Console.WriteLine("Файла с таким именем нет");
            }
        }

        static string GetUpper(string str)
        {
            string retStr = String.Empty;
            foreach (char c in str)
            {
                retStr += c.ToString().ToUpper();
            }
            return retStr;
        }

        static void Task4()
        {
            Console.WriteLine("Упражнение 8.4\n");

        }
        static void Task5()
        {
            Console.WriteLine("Домашнее задание 8.1\n");

            string filePath = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\emails.txt";

            if (File.Exists(filePath))
            {
                string[] readContent = File.ReadAllText(filePath).Split(new[] { "\n" }, StringSplitOptions.None);

                for (int i = 0; i < readContent.Length; i++)
                {
                    ParseEmail(ref readContent[i]);
                }
                File.WriteAllText($"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\ДЗ 8.1.txt", String.Join("", readContent));
                Console.WriteLine("Информация записана в файл resourses/ДЗ 8.1.txt");
            }
            else
            {
                Console.WriteLine("Файла с таким именем нет");
            }
        }

        static void ParseEmail(ref string str)
        {
            str = str.Split(new[] {" # " }, StringSplitOptions.None)[1];
        }

        static void Task6()
        {
            Console.WriteLine("Домашнее задание 8.2\n");

            List<Song> songs = new List<Song>
            {
                new Song() { Name = "Seek and Destroy", Author = "Metallica", Previous = null }
            };
            songs.Add(new Song() { Name = "Nothing else Matters", Author = "Metallica", Previous = songs[0] });
            songs.Add(new Song() { Name = "Papercut", Author = "Linkin Park", Previous = songs[1] });
            songs.Add(new Song() { Name = "From the Inside", Author = "Linkin Park", Previous = songs[2] });

            foreach (Song s in songs)
            {
                Console.WriteLine(s.Title());
            }

            if (songs[1].Equals(songs[1].Previous))
            {
                Console.WriteLine("Песни идентичны");
            }
            else
            {
                Console.WriteLine("Композиции не идентичны");
            }
        }
    }
}