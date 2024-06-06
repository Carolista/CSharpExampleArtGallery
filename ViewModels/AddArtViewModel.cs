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

    public List<SelectListItem> Styles { get; set; } =
        [
            new SelectListItem(Style.ArtNouveau.ToString(), ((int)Style.ArtNouveau).ToString()),
            new SelectListItem(Style.Baroque.ToString(), ((int)Style.Baroque).ToString()),
            new SelectListItem(
                Style.Impressionism.ToString(),
                ((int)Style.Impressionism).ToString()
            ),
            new SelectListItem(Style.Pointillism.ToString(), ((int)Style.Pointillism).ToString()),
            new SelectListItem(Style.Renaissance.ToString(), ((int)Style.Renaissance).ToString()),
            new SelectListItem(Style.Surrealism.ToString(), ((int)Style.Surrealism).ToString())
        ];
}
