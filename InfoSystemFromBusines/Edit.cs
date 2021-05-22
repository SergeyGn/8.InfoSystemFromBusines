using System;
using System.Collections.Generic;
using System.Text;
using static InfoSystemFromBusines.Program;
using static InfoSystemFromBusines.Create;

namespace InfoSystemFromBusines
{
    class Edit
    {
        public static void EditWorkerMenu(List<Worker> workers, List<Department> departments, string nameDepartment)
        {
            Console.Clear();
            Console.WriteLine("[1]Удалить сотрудника" +
                "\n[2]Редактировать сотрудника" +
                "\n[Q]Выход в главное меню");
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    DeleteWorker(workers, departments, nameDepartment);
                    EditWorkerMenu(workers, departments, nameDepartment);
                    break;
                case ConsoleKey.D2:
                    EditWorker(workers,departments,nameDepartment);
                    EditWorkerMenu(workers, departments, nameDepartment);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    EditWorkerMenu(workers, departments, nameDepartment);
                    break;
            }
            SerializeWorkers(workers);
            SerializeDepartment(departments);
        }
        public static void DeleteWorker(List<Worker> workers, List<Department> departments, string nameDepartment)
        {
            Console.Clear();

            if (workers.Count == 0)
            {
                Console.WriteLine("Cотрудников нет.Нажмите любую кнопку для выхода в главное меню");
                Console.ReadKey(true);
                MainMenu();
            }
            else
            {
                List<Worker> listWorkersFromDepartment = new List<Worker>();
                int numberItem = 0;
                for (int i = 0; i < workers.Count; i++)
                {
                    if (workers[i].DepartmentName == nameDepartment)
                    {
                        Console.WriteLine($"[{++numberItem}]{workers[i].FirstName} {workers[i].LastName}");
                        listWorkersFromDepartment.Add(workers[i]);
                    }
                }
                Console.WriteLine("Введите номер сотрудника для удаления");
                int enterNumberDelete = CheckNumber(0, numberItem);
                for (int i = 0; i <= workers.Count; i++)
                {
                    if (workers[i] == listWorkersFromDepartment[enterNumberDelete])
                    {
                        workers.RemoveAt(i);
                        break;
                    }
                }
                for (int i = 0; i < departments.Count; i++)
                {
                    if (departments[i].DepartmentName == nameDepartment)
                    {
                        departments.Add(new Department(departments[i].DepartmentName,
                            departments[i].DateCreateDepartment,
                            departments[i].Quantity - 1,
                            departments[i].IdentifierDepartment));
                        departments.RemoveAt(i);
                        break;
                    }
                }
            }
            SerializeWorkers(workers);
            SerializeDepartment(departments);
        }
        public static void EditWorker(List<Worker> workers,List<Department> departments, string nameDepartment)
        {
            Console.Clear();
            if (workers.Count == 0)
            {
                Console.WriteLine("Cотрудников нет.Нажмите любую кнопку для выхода в главное меню");
                Console.ReadKey(true);
                MainMenu();
            }
            else
            {
                int numberItem = 0;
                List<Worker> listWorkersFromDepartment = new List<Worker>();
                for (int i = 0; i < workers.Count; i++)
                {
                    if (workers[i].DepartmentName == nameDepartment)
                    {
                        Console.WriteLine($"[{++numberItem}]{workers[i].FirstName} {workers[i].LastName}");
                        listWorkersFromDepartment.Add(workers[i]);
                    }
                }

                Console.WriteLine("Введите номер сотрудника для редактирования");
                int enterNumberEdit = CheckNumber(0, numberItem);
                for (int i = 0; i <= workers.Count; i++)
                {
                    if (workers[i] == listWorkersFromDepartment[enterNumberEdit])
                    {
                        string firstName;
                        string lastName;
                        DateTime birthday;
                        DateTime startDateCompany;
                        Department department;
                        string departmentName;
                        string identifier;
                        double coefficientDepartment;
                        if (AskQuestion("Хотите поменять имя?"))
                        {
                            Console.WriteLine("Введите имя сотрудника");
                            firstName = Console.ReadLine();
                        }
                        else
                        {
                            firstName = workers[i].FirstName;
                        }
                        if (AskQuestion("Хотите поменять фамилию?"))
                        {
                            Console.WriteLine("Введите фамилию сотрудника");
                            lastName = Console.ReadLine();
                        }
                        else
                        {
                            lastName = workers[i].LastName;
                        }
                        if (AskQuestion("Хотите поменять дату рождения?"))
                        {
                            Console.WriteLine("Введите дату рождения");
                            birthday = CheckDate();
                        }
                        else
                        {
                            birthday = workers[i].Birthday;
                        }
                        if (AskQuestion("Хотите поменять дату трудоустройства в компании?"))
                        {
                            Console.WriteLine("Введите дату начала работ в компании");
                            startDateCompany = CheckDate();
                        }
                        else
                        {
                            startDateCompany = workers[i].StartDateCompany;
                        }
                        int experience = GetAge(startDateCompany);

                        int age = GetAge(birthday);
                        if (AskQuestion("Хотите изменить департамент?"))
                        {
                            for(int j=0;j<departments.Count;j++)
                            {
                               if(departments[j].DepartmentName==workers[i].DepartmentName)
                                {
                                    departments.Add(new Department(departments[j].DepartmentName,
                                        departments[j].DateCreateDepartment,
                                        departments[j].Quantity - 1,
                                        departments[j].IdentifierDepartment));
                                    departments.RemoveAt(j);
                                    break;
                                }
                            }
                            department = PickDepartment(departments);
                            departmentName = department.DepartmentName;
                            identifier = department.IdentifierDepartment;
                            coefficientDepartment = GetCoefficientDepartment(identifier);
                            for (int j = 0; j < departments.Count; j++)
                            {
                                if (departments[j].DepartmentName == workers[i].DepartmentName)
                                {
                                    departments.Add(new Department(departments[j].DepartmentName,
                                        departments[j].DateCreateDepartment,
                                        departments[j].Quantity + 1,
                                        departments[j].IdentifierDepartment));
                                    break;
                                }
                            }
                        }
                        else
                        {
                            departmentName = workers[i].DepartmentName;
                            identifier = workers[i].Identifier;
                            coefficientDepartment = GetCoefficientDepartment(identifier);
                        }
                        if (AskQuestion("Хотите изменить оклад?"))
                        {
                            salary = CheckNumber(0, 10000000);
                        }
                        else
                        {
                            salary = workers[i].Salary;
                        }
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
                        workers.RemoveAt(i);
                        break;
                    }
                }
            }
            SerializeWorkers(workers);
            SerializeDepartment(departments);
        }
        public static void EditDepartmentMenu(List<Department> departments, List<Worker> workers, string nameDepartment)
        {
            Console.WriteLine("\n[1]Редактировать департамент" +
                "\n[2]Редактировать или убрать сотрудника" +
                "\n[3]Расформировать Департамент" +
                "\n[Q]Выход в главное меню");
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    EditDepartment(departments, workers, nameDepartment);
                    EditDepartmentMenu(departments, workers, nameDepartment);
                    break;
                case ConsoleKey.D2:
                    EditWorkerMenu(workers, departments, nameDepartment);
                    EditDepartmentMenu(departments, workers, nameDepartment);
                    break;
                case ConsoleKey.D3:
                    DeleteDepartment(departments, workers, nameDepartment);
                    EditDepartmentMenu(departments, workers, nameDepartment);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Неправильный ввод");
                    EditDepartmentMenu(departments, workers, nameDepartment);
                    break;
            }
        }
        public static void EditDepartment(List<Department> departments, List<Worker> workers, string nameDepartment)
        {

            Console.Clear();
            bool IsEditDepartment = false;
            bool IsEditWorker = false;
            string newNameDepartment;
            DateTime dateCreate;
            string identifiendDepartment;
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].DepartmentName == nameDepartment)
                {
                    if (AskQuestion("Хотите изменить название департамента?"))
                    {
                        Console.WriteLine("Введите название нового департамента");
                        newNameDepartment = CheckNameDepartment(Console.ReadLine(), departments);
                        IsEditDepartment = true;
                        IsEditWorker = true;
                    }
                    else
                    {
                        newNameDepartment = nameDepartment;
                    }
                    if (AskQuestion("Хотите поменять дату основания департамента?"))
                    {
                        Console.WriteLine("Введите дату основания департамента");
                        dateCreate = CheckDate();
                        IsEditDepartment = true;
                    }
                    else
                    {
                        dateCreate = departments[i].DateCreateDepartment;
                    }
                    if (AskQuestion("Хотите поменять уровень доступа департамента?"))
                    {
                        Console.WriteLine("Выберите уровень доступа");
                        identifiendDepartment = GetIdentifierDepartment();
                        IsEditDepartment = true;
                        IsEditWorker = true;
                    }
                    else
                    {
                        identifiendDepartment = departments[i].IdentifierDepartment;
                    }
                    if (IsEditDepartment == true)
                    {
                        Department departmentEdit = new Department(newNameDepartment,
                            dateCreate,
                            departments[i].Quantity,
                            identifiendDepartment);
                        departments.Add(departmentEdit);
                        if (IsEditWorker == true)
                        {
                            List<Worker> EditWorkers = new List<Worker>();
                            for (int j = 0; j < workers.Count; j++)
                            {
                                if (workers[j].DepartmentName == nameDepartment)
                                {
                                    EditWorkers.Add(new Worker(workers[j].FirstName,
                                        workers[j].LastName,
                                        workers[j].Age,
                                        workers[j].Birthday,
                                        newNameDepartment,
                                        identifiendDepartment,
                                        workers[j].StartDateCompany,
                                        workers[j].Experience,
                                        workers[j].Salary,
                                        GetCoefficientDepartment(identifiendDepartment)));
                                    workers.RemoveAt(j);
                                }
                            }
                            for (int j = 0; j < EditWorkers.Count; j++)
                            {
                                workers.Add(EditWorkers[j]);
                            }
                        }
                    }
                    break;
                }
            }
            SerializeWorkers(workers);
            SerializeDepartment(departments);
        }
        public static void DeleteDepartment(List<Department> departments, List<Worker> workers, string nameDepartment)
        {
            Console.Clear();
            if (departments.Count > 0)
            {
                List<Worker> listWorkersFromDepartment = new List<Worker>();
                if (workers.Count > 0)
                {
                    for (int i = 0; i < workers.Count; i++)
                    {
                        if (workers[i].DepartmentName == nameDepartment)
                        {
                            listWorkersFromDepartment.Add(new Worker(workers[i].FirstName,
                                workers[i].LastName,
                                workers[i].Age,
                                workers[i].Birthday,
                                $"уволен с департамента{workers[i].DepartmentName}",
                                "нет",
                                DateTime.Now,
                                0,
                                salary,
                                0));
                            workers.RemoveAt(i);
                            break;
                        }
                    }
                    for (int i = 0; i < listWorkersFromDepartment.Count; i++)
                    {
                        workers.Add(listWorkersFromDepartment[i]);
                    }
                }
                    for (int i = 0; i <= departments.Count; i++)
                    {
                        if (departments[i].DepartmentName == nameDepartment)
                        {
                            departments.RemoveAt(i);
                            break;
                        }
                    }
                Console.WriteLine("Департамент расформирован");
            }
            SerializeWorkers(workers);
            SerializeDepartment(departments);
        }
    }
}
