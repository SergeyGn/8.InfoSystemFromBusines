using System;
using System.Collections.Generic;
using System.Text;
using static InfoSystemFromBusines.Program;
using static InfoSystemFromBusines.Edit;

namespace InfoSystemFromBusines
{
    class Show
    {
       static public void MenuShow()
        {
            Console.Clear();
            Console.WriteLine("Для просмотра департаментов нажмите 1" +
                "\nДля просмотра сотрудников нажмите 2" +
                "\nДля выхода в главное меню нажмите Q");
            ConsoleKeyInfo enter = Console.ReadKey(true);
            switch (enter.Key)
            {
                case ConsoleKey.D1:
                    ShowDepartment(departments,workers);
                    break;
                case ConsoleKey.D2:
                    ShowWorker(workers, departments);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    Console.WriteLine("Нет такого варианта ответа");
                    Console.Clear();
                    MenuShow();
                    break;
            }
        }
        static void MenuShowDepartmentEnd(List<Department> departments, List<Worker> workers, string nameDepartment)
        {
            Console.WriteLine("[1]Правка" +
                "\n[Q]Выход в главное меню");
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    EditDepartmentMenu(departments, workers, nameDepartment);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    MenuShowDepartmentEnd(departments, workers, nameDepartment);
                    break;
            }
            
        }
        static void MenuShowWorkerEnd(List<Worker> workers, List<Department> departments, string nameDepartment)
        {
            Console.WriteLine("[1]Правка" +
            "\n[Q]Выход в главное меню");
            ConsoleKeyInfo input = Console.ReadKey(true);
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    EditWorkerMenu(workers, departments, nameDepartment);
                    break;
                case ConsoleKey.Q:
                    MainMenu();
                    break;
                default:
                    MenuShowWorkerEnd(workers, departments, nameDepartment);
                    break;
            }
            
        }
        private static void ShowDepartment(List<Department> departments, List<Worker> workers)
        {
            Console.Clear();
            Console.WriteLine("в каком порядке показать департаменты?" +
                "\n[1]по названию" +
                "\n[2]по уровню доступа" +
                "\n[3]по количеству сотрудников" +
                "\n[4]по дате создания департамента" +
                "\n[Q]назад");
            ConsoleKeyInfo input = Console.ReadKey(true);
            
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    departments.Sort((a, b) => a.DepartmentName.CompareTo(b.DepartmentName));
                    break;
                case ConsoleKey.D2:
                    departments.Sort((a, b) => a.IdentifierDepartment.CompareTo(b.IdentifierDepartment));
                    break;
                case ConsoleKey.D3:
                    departments.Sort((a, b) => a.Quantity.CompareTo(b.Quantity));
                    break;
                case ConsoleKey.D4:
                    departments.Sort((a, b) => a.DateCreateDepartment.CompareTo(b.DateCreateDepartment));
                    break;
                case ConsoleKey.Q:
                    MenuShow();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет, попробуйте ещё раз");
                    MenuShow();
                    break;
            }
            Console.Clear();
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]{departments[i].DepartmentName}" +
                    $"\nуровень доступа:{departments[i].IdentifierDepartment}" +
                    $"\nкол-во сотрудников:{departments[i].Quantity}" +
                    $"\nдата создания:{departments[i].DateCreateDepartment.ToShortDateString()}" +
                    $"\n");
            }
            Console.WriteLine("Для дальнейшей работы с департаментом введите его номер");
            int numberItem = CheckNumber(0,departments.Count)-1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Название департамента:{departments[numberItem].DepartmentName}" +
                    $"\nуровень доступа:{departments[numberItem].IdentifierDepartment}" +
                    $"\nкол-во сотрудников:{departments[numberItem].Quantity}" +
                    $"\nдата создания:{departments[numberItem].DateCreateDepartment.ToShortDateString()}" +
                    $"\n");
            Console.ResetColor();
            if(AskQuestion("Показать сотрудников этого департамента?"))
            {
                workers.Sort((a, b) => a.FirstName.CompareTo(b.FirstName));
                for(int i=0;i<workers.Count;i++)
                {
                    if (departments[numberItem].DepartmentName == workers[i].DepartmentName)
                    {
                        Console.WriteLine($"{workers[i].FirstName} {workers[i].LastName}");
                    }
                }
            }
            MenuShowDepartmentEnd(departments, workers, departments[numberItem].DepartmentName);
        }
        
        private static void ShowWorker(List<Worker> workers,List<Department> departments)
        {
            Console.Clear();
            Console.WriteLine("в каком порядке показать сотрудников?" +
                "\n[1]по Фамилии" +
                "\n[2]по департаменту" +
                "\n[3]по уровню доступа" +
                "\n[4]по стажу работы" +
                "\n[5]по зарплате" +
                "\n[6]по количеству полных лет" +
                "\n[Q]назад");
            ConsoleKeyInfo input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D1:
                    workers.Sort((a, b) => a.LastName.CompareTo(b.LastName));
                    break;
                case ConsoleKey.D2:
                    workers.Sort((a, b) => a.DepartmentName.CompareTo(b.DepartmentName));
                    break;
                case ConsoleKey.D3:
                    workers.Sort((a, b) => a.Identifier.CompareTo(b.Identifier));
                    break;
                case ConsoleKey.D4:
                    workers.Sort((a, b) => a.Experience.CompareTo(b.Experience));
                    break;
                case ConsoleKey.D5:
                    workers.Sort((a, b) => a.GetWages().CompareTo(b.GetWages()));
                    break;
                case ConsoleKey.D6:
                    workers.Sort((a, b) => a.Age.CompareTo(b.Age));
                    break;
                case ConsoleKey.Q:
                    MenuShow();
                    break;
                default:
                    Console.WriteLine("Такого варианта нет, попробуйте ещё раз");
                    ShowWorker(workers,departments);
                    break;
            }
            Console.Clear();
            for (int i = 0; i < workers.Count; i++)
            {
                Console.WriteLine($"[{i + 1}]{workers[i].FirstName}-{workers[i].LastName}" +
                    $"\nДепартамент:{workers[i].DepartmentName}" +
                    $"\nуровень доступа:{workers[i].Identifier}" +
                    $"\nстаж работы:{workers[i].Experience}" +
                    $"\nзарплата:{workers[i].GetWages()}" +
                    $"\nкол-во полных лет:{workers[i].Age}" +
                    $"\n");
            }
            Console.WriteLine("Для дальнейшей работы с сотрудником введите его номер");
            int numberItem = CheckNumber(0, workers.Count) - 1;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{workers[numberItem].FirstName} {workers[numberItem].LastName}" +
                $"\nДепартамент:{workers[numberItem].DepartmentName}" +
                $"\nуровень доступа:{workers[numberItem].Identifier}" +
                $"\nстаж работы:{workers[numberItem].Experience}" +
                $"\nзарплата:{workers[numberItem].GetWages()}" +
                $"\nкол-во полных лет:{workers[numberItem].Age}" +
                $"\n");
            Console.ResetColor();
            MenuShowWorkerEnd(workers, departments, workers[numberItem].DepartmentName);
        }
    }
}
