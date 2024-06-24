using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

public class ArtworkDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Details> Details { get; set; }

    public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options)
        : base(options) { }

    // NOTE: I did not use the fluent API to configure my database table relationships
    // But if OnModelCreating was already present and had been used in previous
    // migrations, I would need to add base.OnModelCreating(modelBuilder) to it.
}
