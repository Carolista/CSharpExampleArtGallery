namespace CSharpExampleArtGallery;

public class Artist
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Location { get; set; }

    public List<Artwork> Artworks { get; set; } = [];

    public Artist() { }

    public Artist(string firstName, string lastName, string location)
    {
        FirstName = firstName;
        LastName = lastName;
        Location = location;
    }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }

    public override bool Equals(object? obj)
    {
        return obj is Artist artist && Id == artist.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
