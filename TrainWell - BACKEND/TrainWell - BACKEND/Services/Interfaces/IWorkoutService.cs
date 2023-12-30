using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Training;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<int> AddWorkoutAsync(WorkoutDto workout);

        Task DeleteWorkoutAsync(int id);

        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();

        Task<Workout> GetWorkoutByIdAsync(int id);

        Task UpdateWorkoutAsync(WorkoutUpdateDto workout);
    }
}