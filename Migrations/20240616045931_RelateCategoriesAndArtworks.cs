using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpExampleArtGallery.Migrations
{
    /// <inheritdoc />
    public partial class RelateCategoriesAndArtworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Style",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Artworks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_CategoryId",
                table: "Artworks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Categories_CategoryId",
                table: "Artworks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Categories_CategoryId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_CategoryId",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Artworks");

            migrationBuilder.AddColumn<int>(
                name: "Style",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
