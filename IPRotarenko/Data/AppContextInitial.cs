using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPRotarenko.DAL.Context;
using IPRotarenko.Domain.Entities;

namespace IPRotarenko.Data
{
    public class AppContextInitial
    {
        private readonly ApplicationContext applicationContext;
        public AppContextInitial()
        {
            ApplicationContext applicationContext = new ApplicationContext();
            this.applicationContext = applicationContext;
        }
        public void Initialize()
        {
            if (applicationContext.Products.Any()) return;
            applicationContext.Sections.AddRange(TestData.Sections);
            applicationContext.SaveChanges();
            applicationContext.Products.AddRange(TestData.Products);
            applicationContext.SaveChanges();
        }
        
    }
}
