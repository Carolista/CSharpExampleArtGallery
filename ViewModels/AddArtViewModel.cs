using System.ComponentModel.DataAnnotations;

namespace CSharpExampleArtGallery;

public class AddArtViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Artist is required.")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Artist's name must be 2-30 characters long.")]
    public string? Artist { get; set; }
}
