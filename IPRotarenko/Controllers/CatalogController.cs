using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.Infastructure.Mapping;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IPRotarenko.Controllers
{
    public class CatalogController : Controller
    {
        IProductData _ProductData;
        public CatalogController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        public IActionResult Shop(int? SectionId)
        {
            var filter = new ProductFilter
            {
                SectionId = SectionId,
              
            };
            var products = _ProductData.GetProducts(filter);
            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                Products = products.Select(ProductMapping.ToView).OrderBy(p => p.Order)
            });
        }
        public IActionResult Recipes()
        {
            return View();
        }
        public IActionResult Other()
        {
            return View(new RequestCallViewModel());
        }
        [HttpPost]
        public IActionResult Other(RequestCallViewModel RequestCall)
        {
            if (RequestCall is null)
                throw new ArgumentException(nameof(RequestCall));
            if (!ModelState.IsValid)
                return View(RequestCall);

            //_EmployeesData.Add(new Employee
            //{
            //    FirstName = Employee.Name,
            //    SurName = Employee.SecondName,
            //    Patronymic = Employee.Patronymic,
            //    Age = Employee.Age
            //});
            //_EmployeesData.SaveChanges();
            return RedirectToAction("Shop");
        }


    }
}