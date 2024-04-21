using API.Entities;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using SiliconAppMVC.Models.Sections;
using SiliconAppMVC.Models.Views;
using System.Text;

namespace SiliconAppMVC.Controllers;

public class HomeController(UserManager<AppUser> userManager, HttpClient httpClient) : Controller {
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly HttpClient _httpClient = httpClient;

    public async Task<IActionResult> Index() {
        ViewData["Title"] = "Home";

        AppUser? tUser = await _userManager.GetUserAsync(User);

        return View(new HomeIndexViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(NewsletterModel model) {
        ViewData["Title"] = "Home";
        //AppUser? tUser = await _userManager.GetUserAsync(User);

        if (ModelState.IsValid) {

            var jason = JsonConvert.SerializeObject((SubscriberEntity)model);
            var content = new StringContent(jason, Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync($"https://localhost:7261/api/subscriber", content);
            if (res.IsSuccessStatusCode) {
                ViewData["Message"] = "You were successfully added to subscription list";
            } else if (res.StatusCode == System.Net.HttpStatusCode.Conflict) {
                ViewData["Message"] = "E-mail already exists on subscriptions list";
            }

        }

        return View(new HomeIndexViewModel());
    }

    [Route("/error")]
    public IActionResult Error404(int statusCode) {
        ViewData["Title"] = "Error";

        return View();
    }
}