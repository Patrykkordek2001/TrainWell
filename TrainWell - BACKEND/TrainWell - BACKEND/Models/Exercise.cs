namespace TrainWell___BACKEND.Models
{
    public class Exercise
    {
        public Exercise(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseSet> ExerciseSets { get; set; }
        public virtual Workout Workout { get; set; }
        public int WorkoutId { get; set; }

    }
}

        