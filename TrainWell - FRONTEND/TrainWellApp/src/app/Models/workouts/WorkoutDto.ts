import { ExerciseWorkoutDto } from "./ExerciseWorkoutDto";

export interface WorkoutDto {
    title: string;
    date: Date;
    exercisesWorkout: ExerciseWorkoutDto[];
  }