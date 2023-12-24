using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos.Workouts
{
    public class WorkoutUpdateDto
    {
        public WorkoutUpdateDto(string title, DateTime date, List<ExerciseWorkout> exercisesWorkout, int id)
        {
            Title = title;
            Date = date.ToLocalTime();
            ExercisesWorkout = exercisesWorkout;
            Id = id;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public List<ExerciseWorkout>? ExercisesWorkout { get; set; }
    }
}
