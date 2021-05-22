using System;
using System.Collections.Generic;
using System.Globalization;
using static InfoSystemFromBusines.Create;
using static InfoSystemFromBusines.Show;
using Newtonsoft.Json;
using System.IO;

namespace InfoSystemFromBusines
{
    class Program
    {
        private static string _pathWorkers = "workers.json";
        private static string _pathDepartments = "departments.json";
        public static List<Worker> workers=new List<Worker>();
        public static List<Department> departments=new List<Department>();
        static void Main(string[] args)
        {
            if (CheckFile(_pathDepartments) == true)
            {
                
               departments=GetListDepartment();
            }
            else
            {
                Console.WriteLine("В базе нет департаментов. Нажмите любую кнопку для создания");
                Console.ReadKey(true);
                CreateDepartment(departments);
            }
            if (CheckFile(_pathWorkers) == true)
            {
               workers=GetListWorker();
            }
            else
            {
                Console.WriteLine("В базе нет сотрудников. Нажмите любую кнопку для создания");
                Console.ReadKey(true);
                CreateWorker(workers,departments);
            }
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Для создания департамента или сотрудника нажмите 1" +
                "\nДля просмотра департамента или сотрудника нажмите 2" +
                "\nДля выхода нажмите Q");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    MenuCreate();
                    break;
                case ConsoleKey.D2:
                    MenuShow();
                    break;
                case ConsoleKey.Q:
                    SerializeDepartment(departments);
                    SerializeWorkers(workers);
                    Console.WriteLine("Всего хорошего");
                    break;
                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        private static List<Department> GetListDepartment()
        {
            string jsonDepartments = File.ReadAllText(_pathDepartments);
            departments = JsonConvert.DeserializeObject<List<Department>>(jsonDepartments);
            //процесс десериализации
            return departments;

        }

        private static List<Worker> GetListWorker()
        {
            string jsonWorker = File.ReadAllText(_pathWorkers);
            workers = JsonConvert.DeserializeObject<List<Worker>>(jsonWorker);
            //процесс десериализации
            return workers;
        }

        public static void SerializeWorkers(List<Worker> workers)
        {
            string jsonWorkers = JsonConvert.SerializeObject(workers);
            File.WriteAllText(_pathWorkers, jsonWorkers);
        }
        public static void SerializeDepartment(List<Department> departments)
        {
            string jsonDepartments = JsonConvert.SerializeObject(departments);
            File.WriteAllText(_pathDepartments, jsonDepartments);
        }
        public static Department PickDepartment(List<Department> listDepartment)
        {
            int numberDepartment = 0;
            for (int i = 0; i < listDepartment.Count; i++)
            {
                Console.WriteLine($"[№{++numberDepartment}]{listDepartment[i].DepartmentName}");
            }
            return listDepartment[CheckNumber(0, numberDepartment)];

        }
        public static DateTime CheckDate()
        {
            DateTime date;
            string input;
            do
            {
                Console.WriteLine("Введите дату в формате ДД.MM.ГГГГ");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out date));
            return date;

        }

        public static int CheckNumber(int minValue, int maxValue)
        {
            string number = Console.ReadLine();
            if (int.TryParse(number, out int result) == true)
            {
                result -= 1;
                if (result >= minValue && result < maxValue)
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Вышли за границы ввода");
                    CheckNumber(minValue, maxValue);
                    return minValue;
                }
            }
            else
            {
                Console.WriteLine("Неправильный ввод, должно быть число");
                CheckNumber(minValue, maxValue);
                return minValue;
            }
        }

        private static bool CheckFile(string path)
        {
            bool IsFile;
            if(!File.Exists(path))
            {
                IsFile = false;
            }
            else
            {
                FileInfo file = new FileInfo(path);
                if (file.Length > 10)
                    IsFile = true;
                else
                    IsFile = false;
            }
            return IsFile;
        }

        public static string CheckNameDepartment(string name, List<Department> departments)
        {
            if (departments.Count > 0)
            {
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].DepartmentName.ToLower() == name.ToLower())
                    {
                        Console.WriteLine("Такой департамент уже существует, введите другое название");
                        name = Console.ReadLine();
                        CheckNameDepartment(name, departments);
                    }
                }
            }
            return name;
        }
        public static int GetAge(DateTime countdownDate)
        {
            int years = DateTime.Now.Year - countdownDate.Year;
            int months = DateTime.Now.Month - countdownDate.Month;
            if (months < 0)
            {
                months += 12;
                years -= 1;
            }
            int days = DateTime.Now.Day - countdownDate.Day;
            if (days < 0)
            {
                months -= 1;
                if (months < 0)
                {
                    years -= 1;
                }
            }
            return years;
        }
        public static bool AskQuestion(string question)
        {
            Console.WriteLine($"{question}y/n");
            bool IsYes=false;
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.Y:
                    IsYes = true;
                    break;
                case ConsoleKey.N:
                    IsYes = false;
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    AskQuestion(question);
                    break;
            }
            return IsYes;
        }
    }
}
