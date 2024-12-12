using System;
using System.Collections.Generic;
using System.IO;

namespace Tumakov7
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4(); 
            Task5();
            Task6();

            Console.WriteLine("Пресс самфинг ту эксит...");
            Console.ReadKey();
        }

        /// <summary>
        /// Упражнение 8.1. 
        /// В класс банковский счет, созданный в упражнениях 7.1-3 добавить метод, 
        /// который переводит деньги с одного счета на другой.
        /// У метода два параметра: 
        /// первый - ссылка на объект класса банковский счет, второй – сумма.
        /// </summary>
        /// <returns>-</returns>
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

        /// <summary>
        /// Считывает число с консоли - 1 либо 2 - и возвращает тип банковского аккаунта.
        /// Ввод до победного
        /// </summary>
        /// <returns>Объект типа BankAccount</returns>
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

        /// <summary>
        /// Упражнение 8.2. 
        /// Написать метод, переворачивающий строку 
        /// </summary>
        /// <returns>-</returns>
        static void Task2()
        {
            Console.WriteLine("\nУпражнение 8.2\n");

            Console.WriteLine("Введите строку");
            string s = Console.ReadLine();
            Console.WriteLine(Reverse(s));
        }

        /// <summary>
        /// Принимает строку и переворачивает символы в ней
        /// </summary>
        /// <returns>строка string</returns>
        static string Reverse(string str)
        {
            string retStr = String.Empty;

            for (int i = str.Length - 1; i >= 0; i--)
            {
                retStr += str[i];
            }
            
            return retStr;
        }

        /// <summary>
        /// Упражнение 8.3. 
        /// Программа спрашивает у пользователя имя файла. Если он существует, 
        /// то все символы в файле переводятся в uppercase и записываются в выходной файл.
        /// Если такого файла нет, то предупреждает пользователя
        /// </summary>
        /// <returns>-</returns>
        static void Task3()
        {
            Console.WriteLine("\nУпражнение 8.3\n");

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

        /// <summary>
        /// Переводит строку в uppercase и возвращает её.
        /// </summary>
        /// <returns>Строка string</returns>
        static string GetUpper(string str)
        {
            string retStr = String.Empty;
            foreach (char c in str)
            {
                retStr += c.ToString().ToUpper();
            }
            return retStr;
        }

        /// <summary>
        /// Упражнение 8.4. 
        /// Реализовать метод, который проверяет, реализует ли входной параметр
        /// метода интерфейс System.IFormattable.
        /// Использовать оператор is и as.
        /// </summary>
        /// <returns>-</returns>
        static void Task4()
        {
            Console.WriteLine("\nУпражнение 8.4\n");

            object obj1 = 42;
            IsCheck(obj1);
            AsCheck(obj1);

            object obj2 = "ksvbskdbkvsdj";
            IsCheck(obj2);
            AsCheck(obj2);

            object obj3 = true;
            IsCheck(obj3);
            AsCheck(obj3);
        }

        /// <summary>
        /// Проверяет, реализует ли входной параметр метода интерфейс System.IFormattable. Используется is
        /// </summary>
        /// <returns>-</returns>
        static void IsCheck(object o)
        {
            if (o is IFormattable)
            {
                Console.WriteLine($"{o.GetType().FullName} реализует.");
            }
            else
            {
                Console.WriteLine($"{o.GetType().FullName} не реализует.");
            }
        }

        /// <summary>
        /// Проверяет, реализует ли входной параметр метода интерфейс System.IFormattable. Используется as
        /// </summary>
        /// <returns>-</returns>
        static void AsCheck(object o)
        {
            if (o as IFormattable != null)
            {
                Console.WriteLine($"{o.GetType().Name} реализует.");
            }
            else
            {
                Console.WriteLine($"{o.GetType().Name} не реализует.");
            }
        }

        /// <summary>
        /// Домашнее задание 8.1. 
        /// Дан текстовый файл, содержащий ФИО и e-mail адрес.
        /// Сформировать новый файл, содержащий список адресов электронной почты.
        /// Предусмотреть метод, выделяющий из строки адрес почты. 
        /// </summary>
        /// <returns>-</returns>
        static void Task5()
        {
            Console.WriteLine("\nДомашнее задание 8.1\n");

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

        /// <summary>
        /// Метод делит строку по " # " и возвращает вторую часть - email в данном случае
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>-</returns>
        static void ParseEmail(ref string str)
        {
            str = str.Split(new[] {" # " }, StringSplitOptions.None)[1];
        }

        /// <summary>
        /// Создать список из 4 песен. У каждой песни есть название, автор, предыдущая песня. 
        /// Сравнить 1 и 2 песни в списке.
        /// </summary>
        /// <returns>-</returns>
        static void Task6()
        {
            Console.WriteLine("\nДомашнее задание 8.2\n");

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
