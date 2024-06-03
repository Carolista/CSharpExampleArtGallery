
namespace CSharpExampleArtGallery;

public class Artwork
{
    private static int nextId = 1;

    public int Id { get; } // readonly
    public string Title { get; set; }
    public string Artist { get; set; }  

    public Artwork(string title, string artist)
    {
        Title = title;
        Artist = artist;
        Id = nextId;
        nextId++;
    }

    public override string ToString()
    {
        return Title + " (" + Artist + ")";
    }

    public override bool Equals(object? obj)
    {
        return obj is Artwork artwork &&
               Id == artwork.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
