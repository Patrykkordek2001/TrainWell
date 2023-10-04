namespace TrainWell___BACKEND.Models
{
    public class Exercise
    {
        public Exercise(Guid id, int numberOfRepeats, int numberOfSeries, double weight)
        {
            Id = id;
            NumberOfRepeats = numberOfRepeats;
            NumberOfSeries = numberOfSeries;
            Weight = weight;
        }

        public Guid Id { get; set; }
        public int NumberOfRepeats { get; set; }
        public int NumberOfSeries { get; set; }
        public double Weight { get; set; }
        public virtual Workout Workout { get; set; }
        public int WorkoutId { get; set; }

    }
}

        