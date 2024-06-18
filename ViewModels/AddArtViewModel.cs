using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpExampleArtGallery;

public class AddArtViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    // Form select will return integer value
    public int ArtistId { get; set; }

    // TODO: Remove this once no longer needed
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Year created is required.")]
    public string? YearCreated { get; set; }

    [Required(ErrorMessage = "Media is required.")]
    public string? Media { get; set; }

    // TODO: Add Description, Height, Width, and Depth

    [Required(ErrorMessage = "Image ID is required.")]
    public string? ImageId { get; set; }

    public List<SelectListItem> Artists { get; set; } = [];

    // TODO: Convert this to a list of Category objects
    public List<SelectListItem> Categories { get; set; } = [];

    public AddArtViewModel() { }

    public AddArtViewModel(List<Artist> artistList, List<Category> categoryList)
    {
        foreach (Artist artist in artistList)
        {
            string artistDisplayName = artist.LastName + ", " + artist.FirstName;
            string artistInputValue = artist.Id.ToString();
            Artists.Add(new SelectListItem(artistDisplayName, artistInputValue));
        }

        // TODO: Remove this and just pass the categoryList elements to Categories
        foreach (Category category in categoryList)
        {
            string categoryDisplayName = category.Title ?? "";
            string categoryInputValue = category.Id.ToString();
            Categories.Add(new SelectListItem(categoryDisplayName, categoryInputValue));
        }
    }
}
