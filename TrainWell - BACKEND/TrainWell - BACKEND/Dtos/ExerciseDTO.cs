namespace TrainWell___BACKEND.Dtos
{
    public class ExerciseDTO
    {
        public ExerciseDTO(string name, double weight, ICollection<ExerciseSetDTO> exerciseSets)
        {
            Name = name;
            Weight = weight;
            ExerciseSets = exerciseSets;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public ICollection<ExerciseSetDTO> ExerciseSets { get; set; }
    }
}
