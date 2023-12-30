using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos.Workouts
{
    public class ExerciseWorkoutDto
    {
        public ExerciseWorkoutDto()
        {
        }

        //serie
        public List<ExerciseSet> ExcerciseSets { get; set; }

        //trening (tytul, data)
        //public Workout? Workout { get; set; }
        //public int WorkoutId { get; set; }

        //zbiór ćwiczeń
        //public Exercise? Exercise { get; set; }
        public int ExerciseId { get; set; }
    }
}