using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace CSharpExampleArtGallery;

// If route is unspecified here, it will be /gallery 
// because this is the GalleryController
public class GalleryController : Controller
{

    // GET: /gallery/ (which is the same as /gallery/index.html)
    public IActionResult Index() 
    {
        string html = "<h2>Midtown Art Gallery</h2>" +
            "<p>Welcome! View our <a href='/artworks'>collection</a> of fine art.</p>";
        return Content(html, "text/html");
    }

    /* ARTWORKS */

    // TEST DATA - simulate database
    // private static int nextId = 6;
    // private static readonly Dictionary<int, string> artworks = new() {
    //     { 1, "Girl with a Pearl Earring" },
    //     { 2, "Mona Lisa" },
    //     { 3, "The Birth of Venus" },
    //     { 4, "The Persistence of Memory" },
    //     { 5, "The Starry Night" },
    // };

    // // GET: /gallery/artworks
    // // Corresponds to http://localhost:50xx/gallery/artworks
    // public IActionResult Artworks()
    // {
    //     StringBuilder artworksList = new();
    //     foreach (int artworkId in artworks.Keys)
    //     {
    //         string artwork = artworks[artworkId];
    //         artworksList
    //             .Append("<li><a href='details/")
    //             .Append(artworkId)
    //             .Append("'>")
    //             .Append(artwork)
    //             .Append("</a></li>");
    //     }
    //     string html = "<html>" +
    //         "<body>" +
    //         "<h2>ARTWORKS</h2>" +
    //         "<ul>" +
    //         artworksList +
    //         "</ul>" +
    //         "<p>Click <a href='add'>here</a> to add another artwork.</p>" +
    //         "</body>" +
    //         "</html>";
    //     return Content(html, "text/html");
    // }

    // // GET: /gallery/add
    // // Corresponds to http://localhost:50xx/gallery/add
    // public IActionResult Add()
    // {
    //     string html = "<html>" +
    //         "<body>" +
    //         "<form action='results' method='GET'>" +
    //         "<p>Enter the name of a new work of art:</p>" +
    //         "<input type='text' name='artwork' />" +
    //         "<button type='submit'>Submit</button>" +
    //         "</form>" +
    //         "</body>" +
    //         "</html>";
    //     return Content(html, "text/html");
    // }

    // // GET: /gallery/results
    // // Corresponds to http://localhost:50xx/gallery/results?artwork=Some+Art
    // public IActionResult Results(string artwork)
    // {
    //     artworks.Add(nextId, artwork);
    //     nextId++;
    //     string html = "<html>" +
    //         "<body>" +
    //         "<h3>ARTWORK ADDED</h3>" +
    //         "<p>You have successfully added " + artwork + " to the collection.</p>" +
    //         "<p><a href='add'>Add another artwork</a> or <a href='artworks'>view the updated list</a> of artworks.</p>" +
    //         "</body>" +
    //         "</html>";
    //     return Content(html, "text/html");
    // }

    // // GET: /gallery/details/{artworkId}
    // // Corresponds to http://localhost:50xx/gallery/details/42
    // [HttpGet]
    // [Route("/gallery/details/{artworkId}")]
    // public IActionResult Details(int artworkId)
    // {
    //     Console.WriteLine(artworkId);
    //     string html = "<html>" +
    //         "<body>" +
    //         "<h3>Artwork</h3>" +
    //         "<p><b>ID:</b> " + artworkId + "</p>" +
    //         "<p><b>Name:</b> " + artworks[artworkId] + "</p>" +
    //         "</body>" +
    //         "</html>";
    //     return Content(html, "text/html");
    // }
}
