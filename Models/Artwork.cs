namespace CSharpExampleArtGallery;

public class Artwork
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public Artist? Artist { get; set; }
    public int ArtistId { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }

    // TODO: Move to Details model and add Description, Height, Width, & Depth
    public string? YearCreated { get; set; }
    public string? Media { get; set; }
    public string? ImageId { get; set; }

    public Artwork() { }

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
        return Title + " (" + Artist + ", " + YearCreated + ")";
    }

    public override bool Equals(object? obj)
    {
        return obj is Artwork artwork && Id == artwork.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
