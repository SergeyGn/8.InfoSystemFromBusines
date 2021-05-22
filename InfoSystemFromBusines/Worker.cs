using System;
using System.Collections.Generic;
using System.Text;

namespace InfoSystemFromBusines
{
    class Worker
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _firstName;
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _lastName;
        /// <summary>
        /// Кол-во полных лет
        /// </summary>
        private int _age;
        /// <summary>
        /// День Рождения
        /// </summary>
        private DateTime _birthday;
        /// <summary>
        /// Названия департамента в котором работает сотрудник
        /// </summary>
        private string _departmentName;
        /// <summary>
        /// Уровень доступа
        /// </summary>
        private string _identifier;
        /// <summary>
        /// Дата начала работы в компании
        /// </summary>
        private DateTime _startDateCompany;
        /// <summary>
        /// Опыт работы
        /// </summary>
        private int _expirience;
        /// <summary>
        /// Размер оклада
        /// </summary>
        private double _salary;
        /// <summary>
        /// Коэффициент зависящий от департамента
        /// </summary>
        private double _coefficientDepartment;
        public double GetWages()
        {
            double wages=_salary+_salary*0.1 *_expirience+_salary*_coefficientDepartment;
            return wages;
        }
        public Worker(
            string FirstName, 
            string LastName, 
            int age, DateTime Birthday, 
            string DepartmentName, 
            string Identifier, 
            DateTime StartDateCompany, 
            int Expirience, 
            double Salary, 
            double CoefficientDepartment)
        {
            _firstName = FirstName;
            _lastName = LastName;
            _age = age;
            _birthday = Birthday;
            _departmentName = DepartmentName;
            _identifier = Identifier;
            _startDateCompany = StartDateCompany;
            _expirience = Expirience;
            _salary = Salary;
            _coefficientDepartment = CoefficientDepartment;
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get => _firstName; set => _firstName = value; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get => _lastName; set => _lastName = value; }
        /// <summary>
        /// Кол-во полных лет
        /// </summary>
        public int Age { get => _age; set => _age = value; }
        /// <summary>
        /// День Рождения
        /// </summary>
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        /// <summary>
        /// Уровень доступа
        /// </summary>
        public string Identifier { get => _identifier; set => _identifier = value; }
        /// <summary>
        /// Опыт работы
        /// </summary>
        public int Experience { get => _expirience; set => _expirience = value; }
        /// <summary>
        /// Размер оклада
        /// </summary>
        public double Salary { get => _salary; set => _salary = value; }
        /// <summary>
        /// Дата начала работы в компании
        /// </summary>
        public DateTime StartDateCompany { get => _startDateCompany; set => _startDateCompany = value; }
        /// <summary>
        /// Названия департамента в котором работает сотрудник
        /// </summary>
        internal string DepartmentName { get => _departmentName; set => _departmentName = value; }
        /// <summary>
        /// Коэффициент зависящий от департамента
        /// </summary>
        public double CoefficientDepartment { get => _coefficientDepartment; set => _coefficientDepartment = value; }
    }
}
