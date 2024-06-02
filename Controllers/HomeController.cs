using System.Diagnostics;
using CSharpExampleArtGallery.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery.Controllers;

public class HomeController : Controller
{
    public HomeController() { }

    public IActionResult Index()
    {
        return View();
    }

    // Leave this as-is for now
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
