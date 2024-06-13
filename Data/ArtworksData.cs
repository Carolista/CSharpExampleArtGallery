namespace CSharpExampleArtGallery;

// TODO 11: Delete this file once controller is using DbContext

public class ArtworksData
{
    private static Dictionary<int, Artwork> Artworks = [];

    public static IEnumerable<Artwork> GetAll()
    {
        return Artworks.Values;
    }

    public static void Add(Artwork newArtwork)
    {
        Artworks.Add(newArtwork.Id, newArtwork);
    }

    public static void Remove(int id)
    {
        Artworks.Remove(id);
    }

    public static Artwork GetById(int id)
    {
        return Artworks[id];
    }
}
