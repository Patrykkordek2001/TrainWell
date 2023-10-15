using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models
{

    public class Workout
    {
        public Workout()
        {
        }

        public Workout(int id, string title, DateTime date)
        {
            Id = id;
            Title = title;
            Date = date;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}


