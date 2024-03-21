using Infrastructure.Services;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiliconAppMVC.Models.Views;

namespace SiliconAppMVC.Controllers;

public class AccountController(UserService userService) : Controller {
    private readonly UserService _userService = userService;

    [Route("/account")]
    [HttpGet]
    //[Authorize]
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
    public async Task<IActionResult> SignIn(SignInViewModel model) {
        ViewData["Title"] = "Sign In";

        if (ModelState.IsValid) {
            if (await _userService.SignInAsync(model.FormSignIn))
                return RedirectToAction("Index", "Home");
            else
                model.ErrorMessage = "Wrong email or password";
        }

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
    public async Task<IActionResult> SignUp(SignUpViewModel model) {
        ViewData["Title"] = "Sign Up";

        if (ModelState.IsValid) {
            var tUser = await _userService.CreateUserAsync(model.FormSignUp);
            if (tUser != null)
                //User was successfully created
                return RedirectToAction("AccountDetails");
            else
                model.ErrorMessage = "User with that email already exists";
        }

        return View(model);
    }
}
