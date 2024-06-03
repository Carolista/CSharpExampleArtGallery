using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{

    // TODO 5: Create ArtworksData class to serve as data layer

    // TEST DATA - simulate database
    private static int nextId = 1;
    private static readonly Dictionary<int, Artwork> artworks = [];

    // TODO 6: Refactor to retrieve list from ArtworksData

    // Endpoint: GET http://localhost:50xx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        ViewBag.ArtworkList = artworks.Values; // Loosely typed
        return View("Index"); // Name of template
    }

    // Endpoint: GET http://localhost:50xx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        return View("Add"); // Name of template
    }

    // TODO 6: Refactor to save Artwork object to ArtworksData

    // TODO 8: Refactor again for model binding

    // Endpoint: POST http://localhost:50xx/artworks/add 
    // Parameter has same name as incoming form data
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(string title, string artist)
    {
        artworks.Add(nextId, new Artwork(title, artist));
        nextId++;
        return Redirect("/artworks"); // Route
    }

    // TODO 7: Create Delete template and GET & POST methods
}
