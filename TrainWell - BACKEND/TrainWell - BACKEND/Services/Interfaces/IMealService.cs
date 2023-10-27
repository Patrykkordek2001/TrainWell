using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Diet;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IMealService
    {
        Task<int> AddMealAsync(MealDto mealDto);
        Task DeleteMealAsync(int id);
        Task<IEnumerable<Meal>> GetAllMealsAsync();
        Task<Meal> GetMealByIdAsync(int id);
        Task<IEnumerable<Meal>> GetMealsByDateAsync(DateTime date);
        Task UpdateMealAsync(Meal meal);
    }
}