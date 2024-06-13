using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    // TODO 10: Update methods to use ArtworkDbContext class instead of ArtworksData

    // Endpoint: GET http://localhost:5xxx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        List<Artwork> artworks = new(ArtworksData.GetAll());
        return View("Index", artworks);
    }

    // Endpoint: GET http://localhost:5xxx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        AddArtViewModel addArtViewModel = new();
        return View("Add", addArtViewModel);
    }

    // Endpoint: POST http://localhost:5xxx/artworks/add
    // Parameters have same name as incoming form data ANd model field
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel)
    {
        if (ModelState.IsValid)
        {
            // Use object initializer syntax to create object
            Artwork artwork = new()
            {
                Title = addArtViewModel.Title,
                Artist = addArtViewModel.Artist,
                Style = addArtViewModel.Style
            };
            ArtworksData.Add(artwork);
            return Redirect("/artworks"); // Route
        }
        return View("Add", addArtViewModel);
    }

    // Endpoint: GET http://localhost:5xxx/artworks/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteArtworksForm()
    {
        List<Artwork> artworks = new(ArtworksData.GetAll());
        return View("Delete", artworks);
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
