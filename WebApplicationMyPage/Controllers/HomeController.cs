using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationMyPage.Models;

namespace WebApplicationMyPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeViewModel homeViewModel { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
         }

        public async Task<IActionResult> Index()
        {
             homeViewModel = new HomeViewModel();
             await homeViewModel.Initialization;
             return View(homeViewModel);
        }

    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}