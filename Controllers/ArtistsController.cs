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
        List<Artist> artists = context
            .Artists.Include(a => a.Artworks)
            .OrderBy(a => a.FirstName)
            .ToList();
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
            Artist artist =
                new()
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
        List<Artist> artists = context.Artists.OrderBy(a => a.LastName).ToList();
        return View("Delete", artists);
    }

    // Endpoint: POST http://localhost:5xxx/artists/delete
    [HttpPost("delete")]
    public IActionResult ProcessDeleteArtistsForm(int[] artistIds)
    {
        foreach (int id in artistIds)
        {
            Artist? theArtist = context.Artists.Include(a => a.Artworks).Single(a => a.Id == id);
            if (theArtist != null && theArtist.Artworks.Count == 0)
            {
                context.Artists.Remove(theArtist);
            }
        }
        context.SaveChanges();
        return Redirect("/artists");
    }
}
