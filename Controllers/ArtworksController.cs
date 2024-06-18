﻿using Microsoft.AspNetCore.Mvc;
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
        IOrderedQueryable<Artwork> allArtworks = context
            .Artworks.Include(a => a.Artist)
            .Include(a => a.Category)
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
    // TODO 8: Add action method with path parameter to render artwork details page

    // TODO 6: Create Artworks/Details template for View
    // TODO 15: Update Artwork/Details template to display multiple categories

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
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel)
    {
        if (ModelState.IsValid)
        {
            Artist? theArtist = context.Artists.Find(addArtViewModel.ArtistId);
            // TODO 14: Receive categoryIds as second parameter above and create List
            // Replace theCategory with a list of selected Category objects matching ids
            Category? theCategory = context.Categories.Find(addArtViewModel.CategoryId);
            // TODO 5: Create a new Details object using data from the form and add it to the Artwork object
            Artwork artwork =
                new()
                {
                    Title = addArtViewModel.Title,
                    Artist = theArtist,
                    Category = theCategory,
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
        List<Artwork> artworks = context.Artworks.OrderBy(a => a.Title).ToList();
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
                // TODO 5: Look up details object and if it exists, delete it
                context.Artworks.Remove(theArtwork);
            }
        }
        context.SaveChanges();
        return Redirect("/artworks");
    }
}
