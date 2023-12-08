import { ExerciseWorkoutPreview } from "./ExerciseWorkoutPreview";

export interface WorkoutPreviewWithDetails {
    id: number;
    title: string;
    date: Date;
    exercisesWorkout: ExerciseWorkoutPreview[];
  }