using System;
using System.Collections.Generic;
using System.Text;
using static InfoSystemFromBusines.Program;

namespace InfoSystemFromBusines
{
    class Create
    {
        public static double salary = 12100.00;
      public static void MenuCreate()
       {
            SerializeWorkers(workers);
            SerializeDepartment(departments);
            Console.Clear();
            Console.WriteLine("Для создания департамента нажмите 1" +
                            "\nДля создания сотрудника нажмите 2" +
                            "\nВыход в главное меню нажмите Q");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    CreateDepartment(departments);
                    MenuCreate();
                    break;
                case ConsoleKey.D2:
                    CreateWorker(workers,departments);
                    MenuCreate();
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    Console.Clear();
                    MenuCreate();
                    break;
            }
       }
       public static List<Department> CreateDepartment(List<Department> departments)
        {
            Console.Clear();
            Console.WriteLine("Введите название нового департамента");
            string nameDepartment=Console.ReadLine();
            nameDepartment=CheckNameDepartment(nameDepartment,departments);
            Console.WriteLine("Введите дату основания департамента");
            DateTime dateCreate = CheckDate();
            Console.WriteLine("Выбирете департамент");
            departments.Add(new Department(nameDepartment,dateCreate,0,GetIdentifierDepartment()));
            return departments;   
        }
        public static List<Worker> CreateWorker(List<Worker> workers, List<Department> departments)
        {
            Console.Clear();
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
            Console.WriteLine("Выбирете департамент");
            Department department =new Department();
            department = PickDepartment(departments);
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
                salary,
                coefficientDepartment)
            );
            for (int i = 0; i < departments.Count; i++)//Как проще добаваить количество сотрудников?
            {
                if (departments[i].DepartmentName == departmentName)
                {
                    departments.Add(new Department(departments[i].DepartmentName,
                        departments[i].DateCreateDepartment,
                        departments[i].Quantity + 1,
                        departments[i].IdentifierDepartment));
                    departments.RemoveAt(i);
                    break;
                }
            }
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
       public static string GetIdentifierDepartment()
        {
            string[] nameIdentifierDepartment = new string[4] { "нет", "низкий", "средний", "высокий" };
            Console.WriteLine("Выберите уровень доступа");
            for (int i = 0; i < nameIdentifierDepartment.Length; i++)
            {
                Console.WriteLine($"[{i + 1}]{nameIdentifierDepartment[i]}");
            }
            int result = CheckNumber(0, 4);
            return nameIdentifierDepartment[result];
        }
    }
}
