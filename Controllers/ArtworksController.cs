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

    // Corresponds to http://localhost:50xx/artworks
    [HttpGet]
    [Route("")] // This could also be left out entirely as the base route
    public IActionResult RenderArtworksPage()
    {
        StringBuilder artworksList = new();
        foreach (int artworkId in artworks.Keys)
        {
            string artwork = artworks[artworkId];
            artworksList
                .Append("<li><a href='/artworks/details/")
                .Append(artworkId)
                .Append("'>")
                .Append(artwork)
                .Append("</a></li>");
        }
        string html = "<html>" +
            "<body>" +
            "<h2>ARTWORKS</h2>" +
            "<ul>" +
            artworksList +
            "</ul>" +
            "<p>Click <a href='/artworks/add'>here</a> to add another artwork.</p>" +
            "</body>" +
            "</html>";
        return Content(html, "text/html");
    }

    // Corresponds to http://localhost:50xx/artworks/add for GET
    [HttpGet]
    [Route("add")]
    public IActionResult RenderAddArtworkForm()
    {
        string html = "<html>" +
            "<body>" +
            "<form action='/artworks/add' method='POST'>" +
            "<p>Enter the name of a new work of art:</p>" +
            "<input type='text' name='artwork' />" +
            "<button type='submit'>Submit</button>" +
            "</form>" +
            "</body>" +
            "</html>";
        return Content(html, "text/html");
    }

    // Corresponds to http://localhost:50xx/artworks/add for POST
    [HttpPost]
    [Route("add")]
    public IActionResult ProcessAddArtworkForm(string artwork)
    {
        artworks.Add(nextId, artwork);
        nextId++;
        string html = "<html>" +
            "<body>" +
            "<h3>ARTWORK ADDED</h3>" +
            "<p>You have successfully added " + artwork + " to the collection.</p>" +
            "<p><a href='/artworks/add'>Add another artwork</a> or <a href='/artworks'>view the updated list</a> of artworks.</p>" +
            "</body>" +
            "</html>";
        return Content(html, "text/html");
    }

    // Corresponds to http://localhost:50xx/artworks/details/42
    [HttpGet]
    [Route("details/{artworkId}")]
    public IActionResult RenderArtworkDetailsPage(int artworkId)
    {
        Console.WriteLine(artworkId);
        string html = "<html>" +
            "<body>" +
            "<h3>Artwork</h3>" +
            "<p><b>ID:</b> " + artworkId + "</p>" +
            "<p><b>Name:</b> " + artworks[artworkId] + "</p>" +
            "<hr />" +
            "<p>Return to the full <a href='/artworks'>list</a> of artworks.</p>" +
            "</body>" +
            "</html>";
        return Content(html, "text/html");
    }
}
