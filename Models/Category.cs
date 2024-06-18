namespace CSharpExampleArtGallery;

public class Category
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public List<Artwork> Artworks { get; set; } = [];

    public Category() { }

    public Category(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return Title ?? "";
    }

    public override bool Equals(object? obj)
    {
        return obj is Category Category && Id == Category.Id;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id);
    }
}
