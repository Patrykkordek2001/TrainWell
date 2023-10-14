namespace TrainWell___BACKEND.Models
{
    public class ExerciseSet
    {
        public ExerciseSet(int id, int repetitions, double weight, int exerciseId)
        {
            Id = id;
            Repetitions = repetitions;
            Weight = weight;
            ExerciseId = exerciseId;
        }

        public int Id { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set;}
    }
}
