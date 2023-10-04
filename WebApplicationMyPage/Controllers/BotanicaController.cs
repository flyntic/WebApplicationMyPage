
using Microsoft.AspNetCore.Mvc;
using WebApplicationMyPage.Models;

namespace WebApplicationMyPage.Controllers
{
    public class BotanicaController : Controller
    {
        public BotanicaViewModel botanicaViewModel { get; set; }
        public BotanicaController()
        {
            botanicaViewModel = new();
        }
        public IActionResult Index()
        {
            return View(botanicaViewModel);
        }
        public IActionResult PagePlants(int? Id)
        {
            var Page = botanicaViewModel.PagesOfPlants.Find(p => p.Id == Id);
            if (Page == null) { return Index(); }

            return View( botanicaViewModel.PagesOfPlants.Find(p=>p.Id==Id));
        }
        
    }
}
