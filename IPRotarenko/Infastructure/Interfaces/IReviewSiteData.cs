using IPRotarenko.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Infastructure.Interfaces
{
    public interface IReviewSiteData
    {
        IEnumerable<ReviewSite> GetAll();
        void Add(ReviewSite ReviewSite);
    }
}
