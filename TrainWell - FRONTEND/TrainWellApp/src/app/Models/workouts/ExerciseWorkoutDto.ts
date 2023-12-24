import { ExerciseSetPreview } from "./ExerciseSetPreview";

export interface ExerciseWorkoutDto {
    id: number;
    exerciseSets: ExerciseSetPreview[];
    exerciseId: number;
    workoutId: number;
  }