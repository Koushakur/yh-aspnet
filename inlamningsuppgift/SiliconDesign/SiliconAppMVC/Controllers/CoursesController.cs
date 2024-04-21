using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using SiliconAppMVC.Models.Views;
using Newtonsoft.Json;

namespace SiliconAppMVC.Controllers;

public class CoursesController(HttpClient httpClient) : Controller {
    private readonly HttpClient _httpClient = httpClient;

    [Authorize]
    [Route("/courses")]
    public async Task<IActionResult> Index() {
        ViewData["Title"] = "Courses";
        var vm = new CoursesViewModel();

        var apiCall = await _httpClient.GetAsync("https://localhost:7261/api/course");
        var jsonContent = await apiCall.Content.ReadAsStringAsync();

        vm.Courses = JsonConvert.DeserializeObject<IEnumerable<CourseModel>>(jsonContent)!;

        return View(vm);
    }
}
