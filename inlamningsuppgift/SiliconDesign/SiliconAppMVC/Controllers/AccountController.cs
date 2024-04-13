using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models.Identity;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Models;
using SiliconAppMVC.Models.Views;
using System.Diagnostics;

namespace SiliconAppMVC.Controllers;

public class AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IdentityContext context, AddressService addressService) : Controller {

    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly SignInManager<AppUser> _signInManager = signInManager;
    private readonly IdentityContext _idContext = context;
    private readonly AddressService _addressService = addressService;

    [Authorize]
    [Route("/account")]
    public async Task<IActionResult> AccountDetails() {
        ViewData["Title"] = "Account details";

        var vm = new AccountDetailsViewModel();

        AppUser? tUser = await _userManager.GetUserAsync(User);

        if (tUser != null) {

            vm.FormBasicInfo = new() {
                FirstName = tUser.FirstName,
                LastName = tUser.LastName,
                Email = tUser.Email!,
                Phone = tUser.PhoneNumber!,
                Bio = tUser.Biography,
                ProfileImageURL = "images/profile.png"
            };

            var tAddress = await _addressService.GetAddressAsync(tUser.Id);

            if (tAddress != null) {
                vm.FormAddressInfo = new() {
                    Address1 = tUser.Address.StreetName,
                    Address2 = tUser.Address.StreetName2,
                    PostalCode = tUser.Address.PostalCode,
                    City = tUser.Address.City,
                };
            }
        }


        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> BasicInfo(AccountDetails_BasicInfo_Model model) {

        try {
            if (ModelState.IsValid) {
                AppUser? tUser = await _userManager.GetUserAsync(User);

                if (tUser != null) {
                    tUser.FirstName = model.FirstName;
                    tUser.LastName = model.LastName;
                    tUser.Email = model.Email;
                    tUser.PhoneNumber = model.Phone;
                    tUser.Biography = model.Bio;

                    await _userManager.UpdateAsync(tUser);
                }
            }

        } catch (Exception e) { Debug.WriteLine(e); }

        return RedirectToAction("AccountDetails");
    }

    [HttpPost]
    public async Task<IActionResult> AddressInfo(AccountDetails_AddressInfo_Model model) {

        try {
            if (ModelState.IsValid) {
                AppUser? tUser = await _userManager.GetUserAsync(User);

                await _addressService.CreateOrUpdateAsync(tUser!.Id, model.Address1, model.PostalCode, model.City, model.Address2!);
            }

        } catch (Exception e) { Debug.WriteLine(e); }

        return RedirectToAction("AccountDetails");
    }

    #region SignIn

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

    #endregion

    #region SignUp

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

    #endregion

    public async Task<IActionResult> SignOut(SignUpViewModel model) {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

}
