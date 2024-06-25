namespace CSharpExampleArtGallery;

public class ArtworkDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public string? Categories { get; set; }
    public string? YearCreated { get; set; }
    public string? Media { get; set; }
    public string? Description { get; set; }
    public string? Dimensions { get; set; }
    public string? ImageId { get; set; }

    public ArtworkDTO(Artwork artwork)
    {
        Id = artwork.Id;
        Title = artwork.Title;
        Artist = artwork.Artist?.ToString();
        Categories = artwork.GetFormattedCategories();
        YearCreated = artwork.Details?.YearCreated;
        Media = artwork.Details?.Media;
        Description = artwork.Details?.Description;
        Dimensions = artwork.Details?.GetDimensions();
        ImageId = artwork.ImageId;
    }
}