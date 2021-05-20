using System;
using System.Collections.Generic;
using System.Text;
using static InfoSystemFromBusines.Program;

namespace InfoSystemFromBusines
{
    struct Department
    {
        /// <summary>
        /// Название департамента;
        /// </summary>
        private string _departmentName;
        /// <summary>
        /// Дата создания департамента
        /// </summary>
        private DateTime _dateCreateDepartment;
        /// <summary>
        /// Кол-во сотрудников
        /// </summary>
        private int _quantity;
        /// <summary>
        /// Уровень доступа депортамента;
        /// </summary>
        private string _identifierDepartment;
        
        public string IdentifierDepartment { get => _identifierDepartment; set => _identifierDepartment = value; }
        public string DepartmentName { get => _departmentName; set => _departmentName = value; }
        public DateTime DateCreateDepartament
        {
            get
            {
                _dateCreateDepartment = DateTime.Now;
                return _dateCreateDepartment;
            }
        }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
