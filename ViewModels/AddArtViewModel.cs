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
    public string? Artist { get; set; }

    public Style Style { get; set; }

    [Required(ErrorMessage = "Year created is required.")]
    public string? YearCreated { get; set; }

    [Required(ErrorMessage = "Media is required.")]
    public string? Media { get; set; }

    [Required(ErrorMessage = "Image ID is required.")]
    public string? ImageId { get; set; }

    // To facilitate select inputs on form
    public List<SelectListItem> Styles { get; set; } = [];

    public AddArtViewModel()
    {
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
