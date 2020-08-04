using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Models;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IPRotarenko.Controllers
{
    // Все начинаеться с контролера ... первый запрос идет сюда и вызавает действие ....
   
    public class HomeController : Controller
    {
        //котролер есть действия который возращиют IActionResult или Задачу....
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult Delivery()
        {
            return View();
        }
        public IActionResult Reviews()
        {
            return View(new ReviewSiteViewModel());
        }
        [HttpPost]
        public IActionResult Reviews(ReviewSiteViewModel ReviewSiteViewModel)
        {
            if (ReviewSiteViewModel is null)
                throw new ArgumentException(nameof(ReviewSiteViewModel));
            if (!ModelState.IsValid)
                return View(ReviewSiteViewModel);

            //_EmployeesData.Add(new Employee
            //{
            //    FirstName = Employee.Name,
            //    SurName = Employee.SecondName,
            //    Patronymic = Employee.Patronymic,
            //    Age = Employee.Age
            //});
            //_EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Documents()
        {
            return View();
        }

    }
}