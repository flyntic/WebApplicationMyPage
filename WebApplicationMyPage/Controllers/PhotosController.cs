using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMyPage.Controllers
{
    public class PhotosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
