import { ExerciseSetDto } from "./ExerciseSetDto";
import { WorkoutDto } from "./WorkoutDto";

export interface ExerciseWorkoutDto {
    exerciseSets: ExerciseSetDto[];
    exerciseId: number;
  }