using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    // Endpoint: GET http://localhost:5xxx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        ViewBag.ArtworksList = ArtworksData.GetAll();
        return View("Index"); // Name of template
    }

    // Endpoint: GET http://localhost:5xxx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        return View("Add"); // Name of template
    }

    // Endpoint: POST http://localhost:5xxx/artworks/add
    // Parameters have same name as incoming form data ANd model field
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(Artwork artwork)
    {
        ArtworksData.Add(artwork);
        return Redirect("/artworks"); // Route
    }

    // Endpoint: GET http://localhost:5xxx/artworks/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteArtworksForm()
    {
        ViewBag.ArtworksList = ArtworksData.GetAll();
        return View("Delete"); // Name of template
    }

    // Endpoint: POST http://localhost:5xxx/artworks/delete?artworkIds=1&artworkIds=2 (etc)
    [HttpPost("delete")]
    public IActionResult ProcessDeleteArtworksForm(int[] artworkIds)
    {
        foreach (int id in artworkIds)
        {
            ArtworksData.Remove(id);
        }
        return Redirect("/artworks"); // Route
    }
}
