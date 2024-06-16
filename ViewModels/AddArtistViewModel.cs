using System.ComponentModel.DataAnnotations;

namespace CSharpExampleArtGallery;

public class AddArtistViewModel
{
    [Required(ErrorMessage = "First name is required.")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string? LastName { get; set; }

    public string? Location { get; set; }
}
