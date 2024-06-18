namespace CSharpExampleArtGallery;

public class Artwork
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public Artist? Artist { get; set; }
    public int ArtistId { get; set; }
    // TODO 10: Replace Category and CategoryId with an List<Category> initialized to empty list
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    // TODO 1: Add Details and DetailsId
    public string? ImageId { get; set; }

    // TODO 1: Move to Details model and add Description, Height, Width, & Depth
    public string? YearCreated { get; set; }
    public string? Media { get; set; }

    public Artwork() { }

    // TODO 1: Add Details and set both Details and DetailsId
    // TODO 10: Remove Category & CategoryId altogether
    public Artwork(string title, Artist artist, Category category, string yearCreated, string media, string imageId)
        : this()
    {
        Title = title;
        Artist = artist;
        Category = category;
        YearCreated = yearCreated;
        Media = media;
        ImageId = imageId;
    }

    public override string ToString()
    {
        return Title + " (ID: " + Id + ")";
    }

    public override bool Equals(object? obj)
    {
        return obj is Artwork artwork && Id == artwork.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }

    // TODO 11: Add method to get formatted Categories as a string
}
