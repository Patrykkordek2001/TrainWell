using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class UserIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Measurements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Meals");
        }
    }
}
