using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Training
{
    public class Workout
    {
        public Workout()
        {
        }

        public Workout(string title, DateTime date)
        {
            Title = title;
            Date = date;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ExerciseWorkout>? ExercisesWorkout { get; set; }
        public int UserId { get; set; }

    }
}
