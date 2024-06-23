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
}
