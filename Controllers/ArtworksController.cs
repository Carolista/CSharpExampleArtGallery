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
    [HttpGet]
    public IActionResult RenderArtworksPage()
    {
        List<Artwork> artworks = context
            .Artworks.Include(a => a.Artist)
            .Include(a => a.Category)
            .OrderBy(a => a.Title)
            .ToList();
        return View("Index", artworks);

        // TODO 13: Accept optional artistId as query parameter to display only artworks by that artist
        // TODO 13: Pass in different ViewData["Title"] values depending on artistId being present
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
    public IActionResult ProcessAddArtworkForm(AddArtViewModel addArtViewModel)
    {
        if (ModelState.IsValid)
        {
            Artist? theArtist = context.Artists.Find(addArtViewModel.ArtistId);
            Category? theCategory = context.Categories.Find(addArtViewModel.CategoryId);
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
        List<Artwork> artworks = context
            .Artworks.Include(a => a.Artist)
            .OrderBy(a => a.Title)
            .ToList();
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
