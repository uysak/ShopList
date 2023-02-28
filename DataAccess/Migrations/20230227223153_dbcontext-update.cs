using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dbcontextupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShoppingListItemCategoryMaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShoppingListItemId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListItemCategoryMaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingListItemCategoryMaps_ShoppingListItems_ShoppingListI~",
                        column: x => x.ShoppingListItemId,
                        principalTable: "ShoppingListItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingListItemCategoryMaps_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                       name: "FK_ShoppingListItemCategoryMaps_Categories_CategoryId",
                       column: x => x.CategoryId,
                       principalTable: "Categories",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItemCategoryMaps_ShoppingListId",
                table: "ShoppingListItemCategoryMaps",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItemCategoryMaps_ShoppingListItemId",
                table: "ShoppingListItemCategoryMaps",
                column: "ShoppingListItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListItemCategoryMaps_CategoryId",
                table: "ShoppingListItemCategoryMaps",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingListItemCategoryMaps");
        }
    }
}
