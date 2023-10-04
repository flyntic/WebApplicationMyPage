using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMyPage.Controllers
{
    public class MyDachaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
