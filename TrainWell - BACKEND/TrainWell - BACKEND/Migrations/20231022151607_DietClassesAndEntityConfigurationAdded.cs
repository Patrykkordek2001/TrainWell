using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class DietClassesAndEntityConfigurationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breakfasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breakfasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dinners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dinners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lunches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lunches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SecondBreakfast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondBreakfast", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    Fat = table.Column<double>(type: "float", nullable: true),
                    StaruratedFat = table.Column<double>(type: "float", nullable: true),
                    Carbohydrates = table.Column<double>(type: "float", nullable: true),
                    Sugars = table.Column<double>(type: "float", nullable: true),
                    Fiber = table.Column<double>(type: "float", nullable: true),
                    Proteins = table.Column<double>(type: "float", nullable: true),
                    Salt = table.Column<double>(type: "float", nullable: true),
                    DinnerId = table.Column<int>(type: "int", nullable: true),
                    LunchId = table.Column<int>(type: "int", nullable: true),
                    BreakfastId = table.Column<int>(type: "int", nullable: true),
                    SnackId = table.Column<int>(type: "int", nullable: true),
                    SecondBreakfastId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Breakfasts_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Breakfasts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Dinners_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Dinners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Lunches_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Lunches",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_SecondBreakfast_SecondBreakfastId",
                        column: x => x.SecondBreakfastId,
                        principalTable: "SecondBreakfast",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Products_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BreakfastId",
                table: "Products",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DinnerId",
                table: "Products",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_LunchId",
                table: "Products",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SecondBreakfastId",
                table: "Products",
                column: "SecondBreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SnackId",
                table: "Products",
                column: "SnackId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Breakfasts");

            migrationBuilder.DropTable(
                name: "Dinners");

            migrationBuilder.DropTable(
                name: "Lunches");

            migrationBuilder.DropTable(
                name: "SecondBreakfast");

            migrationBuilder.DropTable(
                name: "Snacks");
        }
    }
}
