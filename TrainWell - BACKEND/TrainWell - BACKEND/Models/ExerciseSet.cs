using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models
{
    public class ExerciseSet
    {
        public ExerciseSet()
        {
        }

        public ExerciseSet(int repetitions, double weight, int exerciseId)
        {
            Repetitions = repetitions;
            Weight = weight;
            ExerciseId = exerciseId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise? Exercise { get; set;}
    }
}
