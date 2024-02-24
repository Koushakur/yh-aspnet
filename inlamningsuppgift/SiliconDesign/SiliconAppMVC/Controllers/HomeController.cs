using Microsoft.AspNetCore.Mvc;
using SiliconAppMVC.Models.Views;

namespace SiliconAppMVC.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {

            ViewData["Title"] = "Home";

            return View(new HomeIndexViewModel());
        }
    }
}
