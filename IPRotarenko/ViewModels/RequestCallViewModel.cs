using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class RequestCallViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя являеться обезательным")]
        public string Name { get; set; }
        [Display(Name = "Телефон")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Телефон являеться обезательным")]
        public string Phone { get; set; }
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Display(Name = "Тема")]
        public string Headline { get; set; }
        [Display(Name = "Письмо")]
        public string Message { get; set; }
    }
}
