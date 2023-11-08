using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNullables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_ExerciseWorkouts_ExerciseWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                unique: true,
                filter: "[ExerciseId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_ExerciseWorkouts_ExerciseWorkoutId",
                table: "ExerciseSets",
                column: "ExerciseWorkoutId",
                principalTable: "ExerciseWorkouts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_ExerciseWorkouts_ExerciseWorkoutId",
                table: "ExerciseSets");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts");

            migrationBuilder.DropIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts");

            migrationBuilder.AlterColumn<int>(
                name: "WorkoutId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "ExerciseWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseWorkoutId",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseWorkouts_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_ExerciseWorkouts_ExerciseWorkoutId",
                table: "ExerciseSets",
                column: "ExerciseWorkoutId",
                principalTable: "ExerciseWorkouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Exercises_ExerciseId",
                table: "ExerciseWorkouts",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseWorkouts_Workouts_WorkoutId",
                table: "ExerciseWorkouts",
                column: "WorkoutId",
                principalTable: "Workouts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
