namespace TrainWell___BACKEND.Dtos
{
    public class ExerciseDto
    {
        public ExerciseDto(string name, ICollection<ExerciseSetDto> exerciseSets)
        {
            Name = name;
            ExerciseSets = exerciseSets;
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExerciseSetDto> ExerciseSets { get; set; }
    }
}

