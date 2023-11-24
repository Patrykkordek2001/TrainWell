using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos.Workouts
{
    public class ExerciseSetDto
    {
        public ExerciseSetDto(int repetitions, double weight)
        {
            Repetitions = repetitions;
            Weight = weight;
        }

        //public int Id { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public int? ExerciseWorkoutId { get; set; }
        public ExerciseWorkout? ExerciseWorkout { get; set; }
    }
}
