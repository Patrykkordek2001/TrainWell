using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos
{
    public class WorkoutDto
    {
        public WorkoutDto(string title, DateTime date, List<ExerciseWorkout> exercisesWorkout)
        {
            Title = title;
            Date = date.ToLocalTime();
            ExercisesWorkout = exercisesWorkout;
        }

        //public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<ExerciseWorkout>? ExercisesWorkout { get; set; }
    }
}

