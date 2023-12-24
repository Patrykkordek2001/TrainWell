using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Training
{
    public class ExerciseSet
    {
        public ExerciseSet()
        {
        }

        public ExerciseSet(int repetitions, double weight, int exerciseWorkoutId)
        {
            Repetitions = repetitions;
            Weight = weight;
            ExerciseWorkoutId = exerciseWorkoutId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public int? ExerciseWorkoutId { get; set; }
        //public virtual ExerciseWorkout? ExerciseWorkout { get; set; }
    }
}
