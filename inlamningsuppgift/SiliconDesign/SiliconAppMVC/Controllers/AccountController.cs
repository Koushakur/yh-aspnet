using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiliconAppMVC.Models.Views;
using System.Diagnostics;

namespace SiliconAppMVC.Controllers;

public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IdentityContext context) : Controller {

    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly IdentityContext _idContext = context;

    [Authorize]
    [Route("/account")]
    public IActionResult AccountDetails() {
        ViewData["Title"] = "Account details";

        return View(new AccountDetailsViewModel());
    }

    [HttpPost]
    [Route("/account")]
    public IActionResult BasicInfo(SignInViewModel model) {
        ViewData["Title"] = "Account details";

        return View(model);
    }

    [HttpPost]
    [Route("/account")]
    public IActionResult AddressInfo(SignInViewModel model) {
        ViewData["Title"] = "Account details";

        return View(model);
    }


    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn() {
        ViewData["Title"] = "Sign In";

        return View(new SignInViewModel());
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model) {
        ViewData["Title"] = "Sign In";

        try {
            if (ModelState.IsValid) {
                var tFormModel = model.FormSignIn;
                var tUser = await _userManager.FindByEmailAsync(tFormModel.Email);
                if (tUser != null) {
                    var tResult = await _signInManager.PasswordSignInAsync(tUser, tFormModel.Password, tFormModel.RememberMe, false);
                    if (tResult.Succeeded)
                        return RedirectToAction("Index", "Home");
                    else
                        model.ErrorMessage = "Wrong email or password";
                }
            }
        } catch (Exception e) { Debug.WriteLine(e); }

        return View(model);
    }


    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp() {
        ViewData["Title"] = "Sign Up";

        return View(new SignUpViewModel());
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model) {
        ViewData["Title"] = "Sign Up";

        try {
            var tFormModel = model.FormSignUp;
            if (ModelState.IsValid) {

                if (!await _idContext.Users.AnyAsync<AppUser>(x => x.Email == tFormModel.Email)) {
                    var tResult = await _userManager.CreateAsync(UserFactory.CreateAppUser(tFormModel), tFormModel.Password);
                    if (tResult.Succeeded)
                        return RedirectToAction("SignIn");
                    else
                        model.ErrorMessage = tResult.Errors.First().Description;
                } else
                    model.ErrorMessage = "A user with that email already exists";

            } else {
                var pVal = new PasswordValidator<AppUser>();
                var tResult = await pVal.ValidateAsync(_userManager, null!, tFormModel.Password);
                if (!tResult.Succeeded) {
                    model.ErrorMessage = tResult.Errors.First().Description;
                }
            }
        } catch (Exception e) { Debug.WriteLine(e); }

        return View(model);
    }

    public async Task<IActionResult> SignOut(SignUpViewModel model) {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

}
