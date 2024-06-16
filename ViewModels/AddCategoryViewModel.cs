using System.ComponentModel.DataAnnotations;

namespace CSharpExampleArtGallery;

public class AddCategoryViewModel
{
    [Required(ErrorMessage = "Title is required.")]
    public string? Title { get; set; }
}
