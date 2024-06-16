using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpExampleArtGallery.Migrations
{
    /// <inheritdoc />
    public partial class RelateArtistsAndArtworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "ArtistId",
                table: "Artworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks",
                column: "ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Artists_ArtistId",
                table: "Artworks",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Artists_ArtistId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_ArtistId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "ArtistId",
                table: "Artworks");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Artworks",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
