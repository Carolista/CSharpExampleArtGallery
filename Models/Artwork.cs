namespace CSharpExampleArtGallery;

public class Artwork
{
    // TODO 6: Remove nextId here and in constructor
    private static int nextId = 1;

    // TODO 6: Give Id a setter
    public int Id { get; }
    public string? Title { get; set; }
    public string? Artist { get; set; }
    public Style Style { get; set; }

    public Artwork()
    {
        Id = nextId;
        nextId++;
    }

    public Artwork(string title, string artist, Style style)
        : this()
    {
        Title = title;
        Artist = artist;
        Style = style;
    }

    public override string ToString()
    {
        return Title + " (" + Artist + ")";
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
