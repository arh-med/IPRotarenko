using IPRotarenko.Data;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<Employee> _Employees = TestData.Employees;
        public void Add(Employee Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (_Employees.Contains(Employee)) return;
            Employee.Id = _Employees.Count == 0 ? 1 : _Employees.Max(e => e.Id) + 1;
            _Employees.Add(Employee);
        }

        public bool Delete(int Id)
        {
            var db_employee = GetById(Id);
            if (db_employee is null)
                return false;

            return _Employees.Remove(db_employee);
        }

        public void Edit(int Id, Employee Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (_Employees.Contains(Employee)) return;

            var db_employee = GetById(Id);
            if (db_employee is null)
                return;

            db_employee.SurName = Employee.SurName;
            db_employee.FirstName = Employee.FirstName;
            db_employee.Patronymic = Employee.Patronymic;
            db_employee.Age = Employee.Age;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _Employees;
        }

        public Employee GetById(int Id)
        {
            return _Employees.FirstOrDefault(e => e.Id == Id);
        }

        public void SaveChanges()
        {
           
        }
    }
}
