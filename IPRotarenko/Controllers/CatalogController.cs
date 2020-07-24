using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
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
                Products = products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                }).OrderBy(p => p.Order)
            });
        }

    }
}