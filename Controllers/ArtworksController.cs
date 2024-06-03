using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{

    // TODO 1: Create an Artwork model with properties Id, Title, and Artist
    
    // TODO 3: Modify Dictionary to hold Artwork objects instead of strings

    // TODO 5: Create ArtworksData class to serve as data layer

    // TEST DATA - simulate database
    private static int nextId = 6;
    private static readonly Dictionary<int, string> artworks = new() {
        { 1, "Girl with a Pearl Earring" },
        { 2, "Mona Lisa" },
        { 3, "The Birth of Venus" },
        { 4, "The Persistence of Memory" },
        { 5, "The Starry Night" },
    };

    // TODO 4: Pass list of Artworks objects, not strings

    // TODO 6: Refactor to retrieve list from ArtworksData

    // Endpoint: GET http://localhost:5xxx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        ViewBag.ArtworksList = artworks.Values;
        return View("Index"); // Name of template
    }

    // Endpoint: GET http://localhost:5xxx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        return View("Add"); // Name of template
    }

    // TODO 3: Modify to accept title and artist,
    // create Artwork object, and set in dictionary above

    // TODO 6: Refactor to save Artwork object to ArtworksData

    // TODO 8: Refactor again for model binding
    // Add no-arg constructor to Artwork

    // Endpoint: POST http://localhost:5xxx/artworks/add 
    // Parameter has same name as incoming form data
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(string artwork)
    {
        artworks.Add(nextId, artwork);
        nextId++;
        return Redirect("/artworks"); // Route
    }

    // TODO 7: Create Delete template and GET & POST methods
}
