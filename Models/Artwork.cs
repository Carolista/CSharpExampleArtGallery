namespace CSharpExampleArtGallery;

public class Artwork
{
    private static int nextId = 1;

    // TODO 2: Update the Model with nullable properties

    public int Id { get; } // readonly
    public string? Title { get; set; }
    public string? Artist { get; set; }

    // TODO 9: Create an enum, Style, and add a property here of that type
    // Update the constructor accordingly
    // Add Style to ViewModel with values for list as well

    public Artwork()
    {
        Id = nextId;
        nextId++;
    }

    public Artwork(string title, string artist)
        : this()
    {
        Title = title;
        Artist = artist;
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
