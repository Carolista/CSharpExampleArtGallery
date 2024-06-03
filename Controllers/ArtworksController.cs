using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{

    // Endpoint: GET http://localhost:50xx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        ViewBag.ArtworkList = ArtworksData.GetAll();
        return View("Index"); // Name of template
    }

    // Endpoint: GET http://localhost:50xx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        return View("Add"); // Name of template
    }

    // TODO 8: Refactor again for model binding

    // Endpoint: POST http://localhost:50xx/artworks/add 
    // Parameter has same name as incoming form data
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(string title, string artist)
    {
        ArtworksData.Add(new Artwork(title, artist));
        return Redirect("/artworks"); // Route
    }

    // TODO 7: Create Delete template and GET & POST methods
}
