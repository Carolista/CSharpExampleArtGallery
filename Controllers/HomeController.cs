using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharpExampleArtGallery.Models;

namespace CSharpExampleArtGallery.Controllers;

public class HomeController : Controller
{
    // TODO: Remove logger-related code

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // TODO: This is already set to render contents of /Views/Home/Index.cshtml
    // Update that template with a link to /artworks
    public IActionResult Index()
    {
        return View();
    }

    // TODO: Remove this and Privacy.cshtml
    public IActionResult Privacy()
    {
        return View();
    }

    // Leave this as-is for now
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
