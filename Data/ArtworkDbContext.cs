﻿using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

public class ArtworkDbContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Category> Categories { get; set; }
    // TODO: Add DbSet for Details

    public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options)
        : base(options) { }
}