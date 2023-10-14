using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class ExerciseSetAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRepeats",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "NumberOfSeries",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ExerciseSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Repetitions = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseSet_Exercises_ExerciseId1",
                        column: x => x.ExerciseId1,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseSet_ExerciseId1",
                table: "ExerciseSet",
                column: "ExerciseId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseSet");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfRepeats",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeries",
                table: "Exercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Exercises",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
