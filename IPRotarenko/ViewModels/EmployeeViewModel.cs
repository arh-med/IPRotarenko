using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPRotarenko.ViewModels
{
    public class EmployeeViewModel
    {
        [HiddenInput(DisplayValue =false)]
        public int Id { get; set; }
        [Display(Name = "Имя")]
        [StringLength(maximumLength:25,MinimumLength = 3, ErrorMessage = "Длина от 3 до 25 символов")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Имя являеться обезательным")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия являеться обезательным")]
        [MinLength(3, ErrorMessage = "Минимальная длина 3 символа")]
        public string SecondName { get; set; }
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        [Display(Name = "Возвраст")]
        public int Age { get; set; }
    }
    
}
