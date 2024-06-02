﻿using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

[Route("/artworks")]
public class ArtworksController : Controller
{
    // TEST DATA - simulate database
    private static int nextId = 6;
    private static readonly Dictionary<int, string> artworks = new() {
        { 1, "Girl with a Pearl Earring" },
        { 2, "Mona Lisa" },
        { 3, "The Birth of Venus" },
        { 4, "The Persistence of Memory" },
        { 5, "The Starry Night" },
    };

    // Endpoint: GET http://localhost:50xx/artworks
    [HttpGet]
    public IActionResult Index() // Action method name must match template name
    {
        ViewBag.links = new Dictionary<string, string>() {
            { "Add", "Add New Artwork" }
        };
        ViewBag.artworkList = artworks.Values;
        return View();
    }

    // Endpoint: GET http://localhost:50xx/artworks/add
    [HttpGet("add")]
    public IActionResult Add()
    {
        ViewBag.links = new Dictionary<string, string>() {
            { "Index", "View All Artworks" }
        };
        return View();
    }

    // Endpoint: POST http://localhost:50xx/artworks/add 
    // Parameter has same name as incoming form data
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(string artwork)
    {
        artworks.Add(nextId, artwork);
        nextId++;
        return Redirect("/artworks");
    }
}
