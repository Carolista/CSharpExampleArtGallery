using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

public class ArtworkDbContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    // TODO 3: Add DbSet for Details

    public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options)
        : base(options) { }
}

// TODO 9: Create a new migration for Details table and update database

// TODO 16: Create a new migration for M2M ArtworksCategories and update database