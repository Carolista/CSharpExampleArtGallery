namespace CSharpExampleArtGallery;

public class Artwork
{
    public int Id { get; set; }
    public string? Title { get; set; }

    // TODO 2: Modify Artist property to be of Artist type and update constructor
    public string? Artist { get; set; }
    // TODO 2: Add ArtistId property

    // TODO 7: Replace Style property with Category property and update constructor
    public Style Style { get; set; }
    // TODO 7: Add CategoryId property

    public string? YearCreated { get; set; }
    public string? Media { get; set; }
    public string? ImageId { get; set; }

    public Artwork() { }

    public Artwork(string title, string artist, Style style, string yearCreated, string media, string imageId)
        : this()
    {
        Title = title;
        Artist = artist;
        Style = style;
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
