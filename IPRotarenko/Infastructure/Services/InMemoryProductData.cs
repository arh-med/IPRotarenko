using IPRotarenko.Data;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services
{
    public class InMemoryProductData : IProductData
    {
        public IEnumerable<Product> GetProducts(ProductFilter Filter = null)
        {
            var query = TestData.Products;
            var resul = new List<Product>();
            if (Filter?.SectionId != null)
            {
                foreach (Product product in query)
                {
                    if (product.SectionId == Filter.SectionId)
                    {
                        resul.Add(product);
                    }
                }
            }
            else
            {
                foreach (Product product in query)
                {
                    resul.Add(product);
                }
            }
               
            return resul;
        }

        public IEnumerable<Section> GetSection()
        {
            return TestData.Sections;
        }
    }
}
