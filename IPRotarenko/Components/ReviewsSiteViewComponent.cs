using IPRotarenko.Domain.Entities;
using IPRotarenko.Infastructure.Interfaces;
using IPRotarenko.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.Components
{
    public class ReviewsSiteViewComponent : ViewComponent
    {
        private readonly IReviewSiteData ReviewSiteData;
        public ReviewsSiteViewComponent(IReviewSiteData ReviewSiteData)
        {
            this.ReviewSiteData = ReviewSiteData;
        }
        public IViewComponentResult Invoke()
        {
            return View(GetReviews());
        }
        private IEnumerable<ReviewSiteViewModel> GetReviews()
        {
            var review = ReviewSiteData.GetAll().ToArray();
            var review_views = review.Select(s => new ReviewSiteViewModel
            {
                Id = s.Id,
                Deliveri = s.Deliveri,
                Email = s.Email,
                Name = s.Name,
                Review = s.Review,
                Stars = s.Stars,
            });
            return review_views;
        }

    }
}
