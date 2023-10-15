namespace TrainWell___BACKEND.Dtos
{
    public class ExerciseDTO
    {
        public ExerciseDTO(string name, ICollection<ExerciseSetDTO> exerciseSets)
        {
            Name = name;
            ExerciseSets = exerciseSets;
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseSetDTO> ExerciseSets { get; set; }
    }
}

