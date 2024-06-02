using System.Text;
using Microsoft.AspNetCore.Mvc;

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
    [HttpGet] // or [HttpGet("")]
    public IActionResult RenderArtworksPage()
    {
        // TODO: Use a template for /artworks
        // Pass list of artworks to template using a ViewBag
        // Later, pass a dictionary of KVPs for second nav menu

        StringBuilder artworksList = new();
        foreach (int artworkId in artworks.Keys)
        {
            string artwork = artworks[artworkId];
            artworksList
                .Append("<li>")
                .Append(artwork)
                .Append("</li>");
        }
        string html =
            "<h2>ARTWORKS</h2>" +
            "<ul>" +
            artworksList +
            "</ul>" +
            "<p>Click <a href='/artworks/add'>here</a> to add another artwork.</p>";
        return Content(html, "text/html");
    }

    // Endpoint: GET http://localhost:50xx/artworks/add
    [HttpGet("add")]
    public IActionResult RenderAddArtworkForm()
    {
        // TODO: Use a template for /artworks/add
        // Later, pass a dictionary of KVPs for second nav menu

        string html =
            "<form action='/artworks/add' method='POST'>" +
            "<p>Enter the name of a new work of art:</p>" +
            "<input type='text' name='artwork' />" +
            "<button type='submit'>Submit</button>" +
            "</form>";
        return Content(html, "text/html");
    }

    // Endpoint: POST http://localhost:50xx/artworks/add 
    // Parameter has same name as incoming form data
    [HttpPost("add")]
    public IActionResult ProcessAddArtworkForm(string artwork)
    {
        artworks.Add(nextId, artwork);
        nextId++;

        // TODO: Instead of providing a template for a confirmation page,
        // redirect to /artworks
        string html =
            "<h3>ARTWORK ADDED</h3>" +
            "<p>You have successfully added " + artwork + " to the collection.</p>" +
            "<p><a href='/artworks/add'>Add another artwork</a> or <a href='/artworks'>view the updated list</a> of artworks.</p>";
        return Content(html, "text/html");
    }
}
