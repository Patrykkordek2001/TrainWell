using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public Exercise(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseSet> ExerciseSets { get; set; }
        public virtual Workout? Workout { get; set; }
        public int WorkoutId { get; set; }

    }
}

        