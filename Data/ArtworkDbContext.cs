using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

public class ArtworkDbContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Details> Details { get; set; }

    public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artwork>()
            .HasMany(e => e.Categories)
            .WithMany(e => e.Artworks)
            .UsingEntity(j => j.ToTable("ArtworksCategories"));
    }
}
