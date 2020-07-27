using IPRotarenko.DAL.Context;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services.InDataBase
{
    public class MySqlProductData : IProductData
    {
        private readonly ApplicationContext applicationContext;

        public MySqlProductData()
        {
            ApplicationContext applicationContext = new ApplicationContext();
            this.applicationContext = applicationContext;
        }
        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            List<Product> products = new List<Product>(applicationContext.Products.ToList());
           
            var resul = new List<Product>();

            if (Filter?.SectionId != null)
            {
                foreach (Product product in products)
                {
                    if (product.SectionId == Filter.SectionId)
                    {
                        resul.Add(product);
                    }
                }
            }
            else
            {
                foreach (Product product in products)
                {
                    resul.Add(product);
                }
            }

            return resul;

            
        }

        public IEnumerable<Section> GetSection()
        {
            return applicationContext.Sections.Include(section => section.Products).AsEnumerable();
        }
    }
}
