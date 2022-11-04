using Microsoft.AspNetCore.Mvc;

namespace AssestmentNET_VictorToscanoDuran.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
