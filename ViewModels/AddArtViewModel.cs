using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpExampleArtGallery;

public class AddArtViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Artist is required.")]
    [StringLength(
        30,
        MinimumLength = 2,
        ErrorMessage = "Artist's name must be 2-30 characters long."
    )]
    
    // Form select will return integer value
    public int ArtistId { get; set; }

    // TODO 8: Replace with int CategoryId since select will return option value
    public Style Style { get; set; }

    [Required(ErrorMessage = "Year created is required.")]
    public string? YearCreated { get; set; }

    [Required(ErrorMessage = "Media is required.")]
    public string? Media { get; set; }

    [Required(ErrorMessage = "Image ID is required.")]
    public string? ImageId { get; set; }

    public List<SelectListItem> Artists { get; set; } = [];

    // TODO 8: Replace Styles with Categories
    public List<SelectListItem> Styles { get; set; } = [];

    public AddArtViewModel() { }

    // TODO 8: Modify 2nd constructor below to accept list of categories
    public AddArtViewModel(List<Artist> artistList)
    {
        foreach (Artist artist in artistList)
        {
            string artistDisplayName = artist.LastName = ", " + artist.FirstName;
            string artistInputValue = artist.Id.ToString();
            Artists.Add(new SelectListItem(artistDisplayName, artistInputValue));
        }

        // TODO 8: Replace code below with loop for categories (similar to artists)
        List<Style> styleList = ((Style[])Enum.GetValues(typeof(Style)))
            .OrderBy(s => s.ToString())
            .ToList();

        foreach (Style style in styleList)
        {
            string styleDisplayName = Utils.GetDisplayName(style.ToString());
            string styleInputValue = ((int)style).ToString();
            Styles.Add(new SelectListItem(styleDisplayName, styleInputValue));
        }
    }
}
