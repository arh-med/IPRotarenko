using IPRotarenko.DAL.Context;
using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Services.InDataBase
{
    public class MySqlReviewSiteData : IReviewSiteData
    {
        private readonly ApplicationContext applicationContext;
        public MySqlReviewSiteData()
        {
            ApplicationContext applicationContext = new ApplicationContext();
            this.applicationContext = applicationContext;
        }
        public void Add(ReviewSite ReviewSite)
        {
            applicationContext.ReviewsSite.Add(ReviewSite);
            applicationContext.SaveChanges();
        }

        public IEnumerable<ReviewSite> GetAll()
        {
            return applicationContext.ReviewsSite.AsEnumerable();
        }
    }
}
