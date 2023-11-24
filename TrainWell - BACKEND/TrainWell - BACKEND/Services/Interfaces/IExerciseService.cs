using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IExerciseService
    {
        Task<Exercise> AddExerciseAsync(ExerciseDto productDto);
        Task DeleteExerciseAsync(int id);
        Task<IEnumerable<Exercise>> GetAllExercisesAsync();
        Task<Exercise> GetExerciseByIdAsync(int id);
        Task UpdateExerciseAsync(Exercise exercise);
    }
}