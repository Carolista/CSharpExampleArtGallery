using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSharpExampleArtGallery.Migrations
{
    /// <inheritdoc />
    public partial class SetM2MRelationshipArtworksCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ArtworksCategories",
                columns: table => new
                {
                    ArtworksId = table.Column<int>(type: "int", nullable: false),
                    CategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtworksCategories", x => new { x.ArtworksId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ArtworksCategories_Artworks_ArtworksId",
                        column: x => x.ArtworksId,
                        principalTable: "Artworks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtworksCategories_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ArtworksCategories_CategoriesId",
                table: "ArtworksCategories",
                column: "CategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtworksCategories");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Artworks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_CategoryId",
                table: "Artworks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Categories_CategoryId",
                table: "Artworks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
