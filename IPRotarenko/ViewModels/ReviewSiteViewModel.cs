using IPRotarenko.Domain.Entities.Base.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class ReviewSiteViewModel : INamedEntity
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Заказ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Номер заказа являеться обезательным")]
        public string Deliveri { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Отзыв")]
        public string Review { get; set; }
        public int Stars { get; set; }
    }
}
