using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Data;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.Models;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IPRotarenko.Controllers
{
   
    public class EmployeesController : Controller
    {
        IEmployeesData _EmployeesData;
        public EmployeesController(IEmployeesData employeesData)
        {
            _EmployeesData = employeesData;
        }

        [Route("users")]
        public IActionResult Index()
        {
            return View(_EmployeesData.GetAll().Select(e => new EmployeeViewModel 
            {
                Id = e.Id,
                Name = e.FirstName,
                SecondName = e.SurName,
                Patronymic = e.Patronymic,
                Age = e.Age
            }));
        }
        [Route("user/{Id}")]
        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        public IActionResult Create()
        {

            return View(new EmployeeViewModel());
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentException(nameof(Employee));
            if (!ModelState.IsValid)
                return View(Employee);
            _EmployeesData.Add(new Employee
            {
                FirstName = Employee.Name,
                SurName = Employee.SecondName,
                Patronymic = Employee.Patronymic,
                Age = Employee.Age
            });
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? Id)
        {
            if (Id is null) return View(new EmployeeViewModel());
            if (Id < 0)
                return BadRequest();
            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;
            if (id == 0)
                _EmployeesData.Add(new Employee
                {
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });
            else
                _EmployeesData.Edit(id, new Employee
                {
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });
            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            if (Id <= 0)
                return BadRequest();
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }
        public IActionResult DeleteConfirmed(int Id)
        {
            _EmployeesData.Delete(Id);
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}