using Microsoft.AspNetCore.Mvc;
using SiliconAppMVC.Models.Views;

namespace SiliconAppMVC.Controllers;

public class AccountController : Controller {

    [Route("/account")]
    [HttpGet]
    public IActionResult AccountDetails() {
        ViewData["Title"] = "Account details";
        return View(new AccountDetailsViewModel());
    }

    [Route("/account")]
    [HttpPost]
    public IActionResult BasicInfo(SignInViewModel model) {
        ViewData["Title"] = "Account details";
        return View(model);
    }

    [Route("/account")]
    [HttpPost]
    public IActionResult AddressInfo(SignInViewModel model) {
        ViewData["Title"] = "Account details";
        return View(model);
    }

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
