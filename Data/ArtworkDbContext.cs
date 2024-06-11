﻿using Microsoft.EntityFrameworkCore;

namespace CSharpExampleArtGallery;

public class ArtworkDbContext : DbContext
{
    public DbSet<Artwork> Artworks { get; set; }

    public ArtworkDbContext(DbContextOptions<ArtworkDbContext> options)
        : base(options) { }
}
