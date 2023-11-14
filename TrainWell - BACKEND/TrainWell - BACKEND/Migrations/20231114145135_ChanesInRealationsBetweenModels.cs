using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class ChanesInRealationsBetweenModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseWorkoutId",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_ExerciseWorkoutId",
                table: "Exercises",
                column: "ExerciseWorkoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_ExerciseWorkouts_ExerciseWorkoutId",
                table: "Exercises",
                column: "ExerciseWorkoutId",
                principalTable: "ExerciseWorkouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_ExerciseWorkouts_ExerciseWorkoutId",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_ExerciseWorkoutId",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "ExerciseWorkoutId",
                table: "Exercises");

            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                unique: true,
                filter: "[ExerciseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
