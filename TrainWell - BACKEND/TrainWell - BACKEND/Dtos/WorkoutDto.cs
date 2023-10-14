using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Dtos
{
    public class WorkoutDto
    {
        public WorkoutDto(string title, DateTime date, ICollection<Exercise> exercises)
        {
            Title = title;
            Date = date;
            Exercises = exercises;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
