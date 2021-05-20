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
               departments=GetListDepartment(departments);
            }
            else
            {
                CreateDepartment(departments);
            }
            if (CheckFile(_pathWorkers) == true)
            {
               workers=GetListWorker(workers);
            }
            else
            {
                CreateWorker(workers,departments);
            }
            MainMenu();
        }
        public static void MainMenu()
        {
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
            }
        }
        public static List<Department> GetListDepartment(List<Department> departments)
        {
            string jsonDepartments = File.ReadAllText(_pathDepartments);
            departments = JsonConvert.DeserializeObject<List<Department>>(jsonDepartments);
            //процесс десериализации
            return departments;

        }

        public static List<Worker> GetListWorker(List<Worker> workers)
        {
            string jsonWorker = File.ReadAllText(_pathWorkers);
            workers = JsonConvert.DeserializeObject<List<Worker>>(jsonWorker);
            //процесс десериализации
            return workers;
        }

        private static void SerializeWorkers(List<Worker> workers)
        {
            string jsonWorkers = JsonConvert.SerializeObject(workers);
            File.WriteAllText(_pathWorkers, jsonWorkers);
        }
        private static void SerializeDepartment(List<Department> departments)
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
            return listDepartment[CheckNumber(0, numberDepartment) - 1];

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
                if (result > minValue && result <= maxValue)
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
                IsFile = true;
            }
            return IsFile;
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
    }
}
