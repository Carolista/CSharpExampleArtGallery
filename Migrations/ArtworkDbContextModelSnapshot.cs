﻿// <auto-generated />
using System;
using CSharpExampleArtGallery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CSharpExampleArtGallery.Migrations
{
    [DbContext(typeof(ArtworkDbContext))]
    partial class ArtworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CSharpExampleArtGallery.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("CSharpExampleArtGallery.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArtistId")
                        .HasColumnType("int");

                    b.Property<string>("ImageId")
                        .HasColumnType("longtext");

                    b.Property<string>("Media")
                        .HasColumnType("longtext");

                    b.Property<int>("Style")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("YearCreated")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Artworks");
                });

            modelBuilder.Entity("CSharpExampleArtGallery.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CSharpExampleArtGallery.Artwork", b =>
                {
                    b.HasOne("CSharpExampleArtGallery.Artist", "Artist")
                        .WithMany("Artworks")
                        .HasForeignKey("ArtistId");

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("CSharpExampleArtGallery.Artist", b =>
                {
                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
