using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    private ArtworkDbContext context;

    public ArtworksController(ArtworkDbContext dbContext)
    {
        context = dbContext;
    }

    // Endpoint: GET http://localhost:5xxx/artworks
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        List<Artwork> artworks = context.Artworks.ToList();
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
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel)
    {
        if (ModelState.IsValid)
        {
            Artwork artwork = new()
            {
                Title = addArtViewModel.Title,
                Artist = addArtViewModel.Artist,
                Style = addArtViewModel.Style
            };
            context.Artworks.Add(artwork); // save to list in DbSet object
            context.SaveChanges(); // push change to database
            return Redirect("/artworks");
        }
        return View("Add", addArtViewModel);
    }

    // Endpoint: GET http://localhost:5xxx/artworks/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteArtworksForm()
    {
        List<Artwork> artworks = context.Artworks.ToList();
        return View("Delete", artworks);
    }

    // Endpoint: POST http://localhost:5xxx/artworks/delete?artworkIds=1&artworkIds=2 (etc)
    [HttpPost("delete")]
    public IActionResult ProcessDeleteArtworksForm(int[] artworkIds)
    {
        foreach (int id in artworkIds)
        {
            Artwork? theArtwork = context.Artworks.Find(id);
            context.Artworks.Remove(theArtwork); // remove one from list
        }
        context.SaveChanges(); // after all have been removed from the list
        return Redirect("/artworks");
    }
}
