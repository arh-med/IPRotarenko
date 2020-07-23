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
        public IEnumerable<Section> GetSection()
        {
            return TestData.Sections;
        }
    }
}
