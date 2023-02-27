using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class shoppinglistitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingListItemId",
                table: "ProductCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ShoppingListItemId",
                table: "ProductCategories",
                column: "ShoppingListItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ShoppingListItems_ShoppingListItemId",
                table: "ProductCategories",
                column: "ShoppingListItemId",
                principalTable: "ShoppingListItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ShoppingListItems_ShoppingListItemId",
                table: "ProductCategories");

            migrationBuilder.DropIndex(
                name: "IX_ProductCategories_ShoppingListItemId",
                table: "ProductCategories");

            migrationBuilder.DropColumn(
                name: "ShoppingListItemId",
                table: "ProductCategories");
        }
    }
}
