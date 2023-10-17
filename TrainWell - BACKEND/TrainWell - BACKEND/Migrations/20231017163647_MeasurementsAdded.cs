using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class MeasurementsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSet_Exercises_ExerciseId",
                table: "ExerciseSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseSet",
                table: "ExerciseSet");

            migrationBuilder.RenameTable(
                name: "ExerciseSet",
                newName: "ExerciseSets");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSet_ExerciseId",
                table: "ExerciseSets",
                newName: "IX_ExerciseSets_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseSets",
                table: "ExerciseSets",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Shoulders = table.Column<double>(type: "float", nullable: false),
                    Chest = table.Column<double>(type: "float", nullable: false),
                    Waist = table.Column<double>(type: "float", nullable: false),
                    Arm = table.Column<double>(type: "float", nullable: false),
                    Thigh = table.Column<double>(type: "float", nullable: false),
                    Hips = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_Exercises_ExerciseId",
                table: "ExerciseSets");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExerciseSets",
                table: "ExerciseSets");

            migrationBuilder.RenameTable(
                name: "ExerciseSets",
                newName: "ExerciseSet");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSets_ExerciseId",
                table: "ExerciseSet",
                newName: "IX_ExerciseSet_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExerciseSet",
                table: "ExerciseSet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSet_Exercises_ExerciseId",
                table: "ExerciseSet",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
