using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    private readonly ArtworkDbContext context;

    public ArtworksController(ArtworkDbContext dbContext)
    {
        context = dbContext;
    }

    // Endpoint: GET http://localhost:5xxx/artworks
    // Endpoint: GET http://localhost:5xxx/artworks?artistId=1
    [HttpGet]
    public IActionResult RenderArtworksPage(int? artistId)
    {
        IQueryable<Artwork> allArtworks = context
            .Artworks.Include(a => a.Artist)
            .Include(a => a.Categories)
            .OrderBy(a => a.Title);

        List<Artwork> artworks;

        if (artistId != null)
        {
            Artist? theArtist = context.Artists.Find(artistId);
            if (theArtist != null)
            {
                ViewData["Title"] = "ARTWORKS BY " + theArtist.ToString().ToUpper();
                artworks = allArtworks.Where(a => a.ArtistId == artistId).ToList();
                return View("Index", artworks);
            }
        }
        ViewData["Title"] = "ALL ARTWORKS";
        artworks = allArtworks.ToList();
        return View("Index", artworks);
    }

    // Endpoint: GET http://localhost:5xxx/artworks/details/1
    [HttpGet("details/{artworkId}")]
    public IActionResult RenderArtworkDetailsPage(int artworkId)
    {
        Artwork? requestedArtwork = context.Artworks.Find(artworkId);
        if (requestedArtwork != null)
        {
            Artwork theArtwork = context
                .Artworks.Include(a => a.Artist)
                .Include(a => a.Categories)
                .Include(a => a.Details)
                .Single(a => a.Id == artworkId);
            return View("Details", theArtwork);
        }
        return View("Index");
    }

    // Endpoint: GET http://localhost:5xxx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        List<Artist> artists = context.Artists.OrderBy(a => a.LastName).ToList();
        List<Category> categories = context.Categories.OrderBy(c => c.Title).ToList();
        AddArtViewModel addArtViewModel = new(artists, categories);
        return View("Add", addArtViewModel);
    }

    // Endpoint: POST http://localhost:5xxx/artworks/add
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel, int[] categoryIds)
    {
        if (ModelState.IsValid)
        {
            Artist? theArtist = context.Artists.Find(addArtViewModel.ArtistId);
            List<int> categoryIdList = [.. categoryIds];
            List<Category> selectedCategories = context
                .Categories.Where(c => categoryIdList.Contains(c.Id))
                .ToList();
            Details theDetails =
                new()
                {
                    YearCreated = addArtViewModel.YearCreated,
                    Media = addArtViewModel.Media,
                    Description = addArtViewModel.Description,
                    Height = addArtViewModel.Height,
                    Width = addArtViewModel.Width,
                    Depth = addArtViewModel.Depth
                };
            Artwork artwork =
                new()
                {
                    Title = addArtViewModel.Title,
                    Artist = theArtist,
                    Categories = selectedCategories,
                    Details = theDetails,
                    ImageId = addArtViewModel.ImageId
                };
            context.Artworks.Add(artwork);
            context.SaveChanges();
            return Redirect("/artworks");
        }
        return View("Add", addArtViewModel);
    }

    // Endpoint: GET http://localhost:5xxx/artworks/delete
    [HttpGet("delete")]
    public IActionResult RenderDeleteArtworksForm()
    {
        List<Artwork> artworks = context.Artworks.OrderBy(a => a.Title).ToList();
        return View("Delete", artworks);
    }

    // Endpoint: POST http://localhost:5xxx/artworks/delete?artworkIds=1&artworkIds=2 (etc)
    [HttpPost("delete")]
    public IActionResult ProcessDeleteArtworksForm(int[] artworkIds)
    {
        foreach (int id in artworkIds)
        {
            Artwork? theArtwork = context.Artworks.Include(a => a.Details).Single(a => a.Id == id);
            if (theArtwork != null)
            {
                Details? theDetails = context.Details.Find(theArtwork.DetailsId);
                if (theDetails != null)
                {
                    context.Details.Remove(theDetails);
                }
                context.Artworks.Remove(theArtwork);
            }
        }
        context.SaveChanges();
        return Redirect("/artworks");
    }
}
