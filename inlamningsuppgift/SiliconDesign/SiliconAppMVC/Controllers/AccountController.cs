using Microsoft.AspNetCore.Mvc;
using SiliconAppMVC.Models.Views;

namespace SiliconAppMVC.Controllers;

public class AccountController : Controller {

    [Route("/signin")]
    [HttpGet]
    public IActionResult SignIn() {
        ViewData["Title"] = "Sign In";
        return View(new SignInViewModel());
    }

    [Route("/signin")]
    [HttpPost]
    public IActionResult SignIn(SignInViewModel model) {
        ViewData["Title"] = "Sign In";
        return View(model);
    }

    [Route("/signup")]
    [HttpGet]
    public IActionResult SignUp() {
        ViewData["Title"] = "Sign Up";
        return View(new SignUpViewModel());
    }

    [Route("/signup")]
    [HttpPost]
    public IActionResult SignUp(SignUpViewModel model) {
        ViewData["Title"] = "Sign Up";
        return View(model);
    }
}
