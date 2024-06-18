using System.Text;

namespace CSharpExampleArtGallery;

public class Artwork
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public Artist? Artist { get; set; }
    public int ArtistId { get; set; }
    public ICollection<Category> Categories { get; set; } = new List<Category>();
    public Details? Details { get; set; }
    public int DetailsId { get; set; }
    public string? ImageId { get; set; }

    public Artwork() { }

    public Artwork(string title, Artist artist, Details details, string imageId)
        : this()
    {
        Title = title;
        Artist = artist;
        ArtistId = artist.Id;
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

    public string GetFormattedCategories()
    {
        return string.Join(", ", Categories);
    }
}
