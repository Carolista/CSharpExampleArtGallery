using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

[Route("/artists")]
public class ArtistsController : Controller
{
    private readonly ArtworkDbContext context;

    public ArtistsController(ArtworkDbContext dbContext)
    {
        context = dbContext;
    }

    // Endpoint: GET http://localhost:5xxx/artists
    [HttpGet("")]
    public IActionResult RenderArtistsPage()
    {
        // TODO 13: Include artworks list and order by first name
        List<Artist> artists = context.Artists.ToList();
        return View("Index", artists);
    }

    // Endpoint: GET http://localhost:5xxx/artists/add
    [HttpGet("add")]
    public IActionResult RenderAddArtistForm()
    {
        AddArtistViewModel addArtistViewModel = new();
        return View("Add", addArtistViewModel);
    }

    // Endpoint: POST http://localhost:5xxx/artists/add
    [HttpPost("add")]
    public IActionResult ProcessAddArtistForm(AddArtistViewModel addArtistViewModel)
    {
        if (ModelState.IsValid)
        {
            Artist artist = new()
            {
                FirstName = addArtistViewModel.FirstName,
                LastName = addArtistViewModel.LastName,
                Location = addArtistViewModel.Location,
            };
            context.Artists.Add(artist);
            context.SaveChanges();
            return Redirect("/artists");
        }
        return View("Add", addArtistViewModel);
    }

    // Endpoint: GET http://localhost:5xxx/artists/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteArtistsForm()
    {
        // TODO 1: Order by last name
        List<Artist> artists = context.Artists.ToList();
        return View("Delete", artists);
    }

    // Endpoint: POST http://localhost:5xxx/artists/delete 
    [HttpPost("delete")]
    public IActionResult ProcessDeleteArtistsForm(int[] artistIds)
    {
        foreach (int id in artistIds)
        {
            Artist? theArtist = context.Artists.Find(id);
            if (theArtist != null)
            {
                context.Artists.Remove(theArtist);
            }
        }
        context.SaveChanges();
        return Redirect("/artists");
    }

}
