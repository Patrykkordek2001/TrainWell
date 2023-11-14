using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Training
{
    public class Exercise
    {
            public Exercise()
        {
        }

        public Exercise(string name)
        {
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ExerciseWorkout>? ExerciseWorkouts { get; set; }


    }
}
