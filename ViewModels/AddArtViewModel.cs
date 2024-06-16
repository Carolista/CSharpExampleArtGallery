using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpExampleArtGallery;

public class AddArtViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    // TODO 3: Replace with int ArtistId since select will return option value
    // Remove validation rules
    [Required(ErrorMessage = "Artist is required.")]
    [StringLength(
        30,
        MinimumLength = 2,
        ErrorMessage = "Artist's name must be 2-30 characters long."
    )]
    public string? Artist { get; set; }

    // TODO 8: Replace with int CategoryId since select will return option value
    public Style Style { get; set; }

    [Required(ErrorMessage = "Year created is required.")]
    public string? YearCreated { get; set; }

    [Required(ErrorMessage = "Media is required.")]
    public string? Media { get; set; }

    [Required(ErrorMessage = "Image ID is required.")]
    public string? ImageId { get; set; }

    // TODO 3: Add List of SelectListItem objects for Artists and initialize to empty list
    // TODO 8: Replace Styles with Categories
    public List<SelectListItem> Styles { get; set; } = [];

    // TODO 3: Create no-arg constructor and modify constructor below to accept list of artists

    // TODO 8: Modify 2nd constructor below to accept list of categories
    public AddArtViewModel()
    {
        // TODO 3: Loop over artists to create SelectListItem objects and fill list

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
