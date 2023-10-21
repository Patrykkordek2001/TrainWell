namespace TrainWell___BACKEND.Dtos
{
    public class ExerciseSetDto
    {
        public ExerciseSetDto(int repetitions, double weight)
        {
            Repetitions = repetitions;
            Weight = weight;
        }

        //public int Id { get; set; }
        public int Repetitions { get; set; }
        public double Weight { get; set; }
    }
}
