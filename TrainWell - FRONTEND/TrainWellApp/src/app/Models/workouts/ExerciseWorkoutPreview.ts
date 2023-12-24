import { ExerciseSetPreview } from "./ExerciseSetPreview";

export interface ExerciseWorkoutPreview {
    id:number;
    exerciseSets: ExerciseSetPreview[];
    exerciseId: number;
    workoutId:number;
  }