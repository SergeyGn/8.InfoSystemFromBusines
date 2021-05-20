using System;
using System.Collections.Generic;
using System.Text;
using static InfoSystemFromBusines.Program;

namespace InfoSystemFromBusines
{
    class Create
    {
        private static double _salary = 12100.00;
      public static void MenuCreate()
       {
            Console.WriteLine("Для создания департамента нажмите 1" +
                            "\nДля создания сотрудника нажмите 2" +
                            "\nВыход в главное меню нажмите Q");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    CreateDepartment(departments);
                    break;
                case ConsoleKey.D2:
                    CreateWorker(workers,departments);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
            }
       }
       public static List<Department> CreateDepartment(List<Department> departments)
        {
            Console.WriteLine("Введите название нового департамента");
            string nameDepartment = Console.ReadLine();
            departments.Add(new Department() { DepartmentName = nameDepartment,
                                               IdentifierDepartment=GetIdentifierDepartment(),
                                               Quantity = 0 });
            return departments;   
        }
        public static List<Worker> CreateWorker(List<Worker> workers, List<Department> departments)
        {
            Console.WriteLine("Введите имя нового сотрудника");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите фамилию нового сотрудника");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите дату рождения");
            DateTime birthday = CheckDate();

            Console.WriteLine("Введите дату начала работ в компании");
            DateTime startDateCompany = CheckDate();

            int experience = GetAge(startDateCompany);

            int age = GetAge(birthday);

            Department department = PickDepartment(departments);
            string departmentName = department.DepartmentName;
            string identifier = department.IdentifierDepartment;
            double coefficientDepartment = GetCoefficientDepartment(identifier);

            workers.Add(new Worker(firstName,
                lastName,
                age,
                birthday,
                departmentName,
                identifier,
                startDateCompany,
                experience,
                _salary,
                coefficientDepartment)
            ) ;
            department.Quantity += 1;
            return workers;

        }
        public static double GetCoefficientDepartment(string identifierDepartment)
        {
            double coefficient = 0;
            switch (identifierDepartment)
            {
                case "нет":
                    coefficient = 0;
                    break;
                case "низкий":
                    coefficient = 0.5;
                    break;
                case "средний":
                    coefficient = 1;
                    break;
                case "высокий":
                    coefficient = 2;
                    break;
            }
            return coefficient;
        }
        static string GetIdentifierDepartment()
        {
            string[] nameIdentifierDepartment = new string[4] { "нет", "низкий", "средний", "высокий" };
            Console.WriteLine("Выберите уровень доступа");
            for (int i = 0; i < nameIdentifierDepartment.Length; i++)
            {
                Console.WriteLine($"[{i + 1}]{nameIdentifierDepartment[i]}");
            }
            int result = CheckNumber(0, 4) - 1;
            return nameIdentifierDepartment[result];
        }
    }
}
