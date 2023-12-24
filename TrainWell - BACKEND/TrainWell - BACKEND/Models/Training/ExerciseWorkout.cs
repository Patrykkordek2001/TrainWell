using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainWell___BACKEND.Models.Training
{
    public class ExerciseWorkout
    {
        public ExerciseWorkout()
        {
        }



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //serie
        public ICollection<ExerciseSet>? ExerciseSets { get; set; }

        //trening (tytul, data)
        //public virtual Workout? Workout { get; set; }
        public int? WorkoutId { get; set; }

        //zbiór ćwiczeń
        public virtual Exercise? Exercise{ get; set; }
        public int? ExerciseId { get; set; }
    }
}
