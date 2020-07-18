using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IPRotarenko.Controllers
{ 
    // Все начинаеться с контролера ... первый запрос идет сюда и вызавает действие ....
    public class HomeController : Controller
    {
        //котролер есть действия который возращиют IActionResult или Задачу....
        //public async Task<IActionResult> Index()
        //{
        //    return View();
        //}
        public IActionResult Index()
        {
            return View();
        }
    }
}