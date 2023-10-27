using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class ProductsInMealsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductsInMeal_ProductId",
                table: "ProductsInMeal");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInMeal_ProductId",
                table: "ProductsInMeal",
                column: "ProductId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductsInMeal_ProductId",
                table: "ProductsInMeal");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsInMeal_ProductId",
                table: "ProductsInMeal",
                column: "ProductId");
        }
    }
}
