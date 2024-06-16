using Microsoft.AspNetCore.Mvc;

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
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        // TODO 4: Modify to include artist object and order by artwork title
        // TODO 9: Modify to include category object
        List<Artwork> artworks = context.Artworks.ToList();
        return View("Index", artworks);

        // TODO 13: Accept optional artistId as query parameter to display only artworks by that artist
        // TODO 13: Pass in different ViewData["Title"] values depending on artistId being present
    }

    // Endpoint: GET http://localhost:5xxx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        // TODO 4: Pass artists into constructor (order by last name)
        // TODO 9: Pass categories into constructor (order by title)
        AddArtViewModel addArtViewModel = new();
        return View("Add", addArtViewModel);
    }

    // Endpoint: POST http://localhost:5xxx/artworks/add
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel)
    {
        if (ModelState.IsValid)
        {
            // TODO 4: Look up artist and assign to artist below
            // TODO 9: Look up category and assign to artist below
            Artwork artwork = new()
            {
                Title = addArtViewModel.Title,
                Artist = addArtViewModel.Artist,
                Style = addArtViewModel.Style,
                YearCreated = addArtViewModel.YearCreated,
                Media = addArtViewModel.Media,
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
        // TODO 4: Include artists and order by artwork title
        // TODO 9: Include categories
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
            if (theArtwork != null)
            {
                context.Artworks.Remove(theArtwork);
            }
        }
        context.SaveChanges();
        return Redirect("/artworks");
    }
}
