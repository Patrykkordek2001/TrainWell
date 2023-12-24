import { ExerciseWorkoutDto } from "./ExerciseWorkoutDto";

export interface WorkoutDto {
    id : number;
    title: string;
    date: Date;
    exercisesWorkout: ExerciseWorkoutDto[];
  }