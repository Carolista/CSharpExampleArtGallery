using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpExampleArtGallery;

public class AddArtViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    // Form select will return integer value
    public int ArtistId { get; set; }
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Year created is required.")]
    public string? YearCreated { get; set; }

    [Required(ErrorMessage = "Media is required.")]
    public string? Media { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [StringLength(150, ErrorMessage = "Description cannot be longer than 150 characters.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Height is required.")]
    public double? Height { get; set; }

    [Required(ErrorMessage = "Width is required.")]
    public double? Width { get; set; }

    public double? Depth { get; set; }

    [Required(ErrorMessage = "Image ID is required.")]
    public string? ImageId { get; set; }

    public List<SelectListItem> Artists { get; set; } = [];

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

        foreach (Category category in categoryList)
        {
            string categoryDisplayName = category.Title ?? "";
            string categoryInputValue = category.Id.ToString();
            Categories.Add(new SelectListItem(categoryDisplayName, categoryInputValue));
        }
    }
}
