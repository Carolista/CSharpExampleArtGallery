using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    // TODO 1: Create a ViewModel for the /Artworks/Add form
    
    // TODO 3: Update the GET action methods for Index and Delete to pass a List of Artwork objects (create from the IEnumerable object) instead of using a ViewBag

    // TODO 5: Update the GET action method for Add to pass an AddArtViewModel object

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
        // TODO 7: In ViewModel, Add validation attributes to require 
        // title & artist and ensure artist's name is 2-30 characters long
        // Then add logic below to send user back to form if invalid
        // TODO 9: Add required Style property and values to ViewModel and update code below
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
