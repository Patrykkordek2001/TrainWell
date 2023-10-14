using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IWorkoutService
    {
        Task<int> AddWorkoutAsync(WorkoutDto workout);
        Task DeleteWorkoutAsync(Guid id);
        Task<IEnumerable<Workout>> GetAllWorkoutsAsync();
        Task<Workout> GetWorkoutByIdAsync(Guid id);
        Task UpdateWorkoutAsync(Workout workout);
    }
}