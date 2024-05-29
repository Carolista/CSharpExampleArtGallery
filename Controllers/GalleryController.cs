using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

// With conventional routing, the base route is /gallery
// because it is named GalleryController
public class GalleryController : Controller
{
    // Endpoint: GET /gallery (same as /gallery/index.html)
    public IActionResult Index() 
    {
        return Content("<h1>Welcome!</h1>", "text/html");
    }

    /* ARTWORKS */

    // TEST DATA - simulate database
    private static int nextId = 6;
    private static readonly Dictionary<int, string> artworks = new() {
        { 1, "Girl with a Pearl Earring" },
        { 2, "Mona Lisa" },
        { 3, "The Birth of Venus" },
        { 4, "The Persistence of Memory" },
        { 5, "The Starry Night" },
    };

    // STATIC GET EXAMPLE - Displaying data on a page

    // Endpoint: GET /gallery/collection
    // Corresponds to http://localhost:50xx/gallery/collection
    public IActionResult Collection()
    {
        StringBuilder artworksList = new();
        foreach (int id in artworks.Keys)
        {
            string artwork = artworks[id];
            artworksList.Append(artwork).Append("<br />");
        }
        string html = artworksList.ToString();
        return Content(html, "text/html");
    }

    // STATIC GET EXAMPLE - DISPLAYING A FORM

    // Endpoint: GET /gallery/add
    // Corresponds to http://localhost:50xx/gallery/add
    public IActionResult Add()
    {
        string html = 
            "<form action='/gallery/results'>" +
            "<label>Artwork name: <input type='text' name='artwork' /></label>" +
            "<button type='submit'>Submit</button>" +
            "</form>";
        return Content(html, "text/html");
    }

    // DYNAMIC GET EXAMPLE - QUERY PARAMETER

    // Endpoint: GET /gallery/results
    // Corresponds to http://localhost:50xx/gallery/results?artwork=Some+Art
    public IActionResult Results(string artwork)
    {
        artworks.Add(nextId, artwork);
        nextId++;
        string html = 
            "<p>You have successfully added " + artwork + " to the collection.</p>";
        return Content(html, "text/html");
    }

    // DYNAMIC GET EXAMPLE - PATH PARAMETER

    // Endpoint: GET /gallery/details/{id}
    // Corresponds to http://localhost:50xx/gallery/details/42
    public IActionResult Details(int id)
    {
        string html = 
            "This is the details page for " + artworks[id];
        return Content(html, "text/html");
    }
}
