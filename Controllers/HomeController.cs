using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharpExampleArtGallery.Models;

namespace CSharpExampleArtGallery.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // TODO 2: This is already set to load /Views/Home/Index.cshtml
    // Go to that file and make some changes
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
