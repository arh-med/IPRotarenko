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
            if (applicationContext.Recipes.Any()) return;
            applicationContext.Recipes.AddRange(TestData.Recipes);
            applicationContext.SaveChanges();
            applicationContext.RequestsCall.AddRange(TestData.Requests);
            applicationContext.SaveChanges();
            applicationContext.ReviewsSite.AddRange(TestData.Reviews);
            applicationContext.SaveChanges();
        }
        
    }
}
