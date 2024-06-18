namespace CSharpExampleArtGallery;

public class Artwork
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public Artist? Artist { get; set; }
    public int ArtistId { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
    public Details? Details { get; set; }
    public int DetailsId { get; set; }
    public string? ImageId { get; set; }

    public Artwork() { }

    public Artwork(string title, Artist artist, Category category, Details details, string imageId)
        : this()
    {
        Title = title;
        Artist = artist;
        ArtistId = artist.Id;
        Category = category;
        CategoryId = category.Id;
        Details = details;
        DetailsId = details.Id;
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
}
