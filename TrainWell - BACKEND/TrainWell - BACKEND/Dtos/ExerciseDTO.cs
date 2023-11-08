using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Dtos
{
    public class ExerciseDto
    {
        public ExerciseDto(string name)
        {
            Name = name;
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public ExerciseWorkout? ExerciseWorkout { get; set; }

    }
}

