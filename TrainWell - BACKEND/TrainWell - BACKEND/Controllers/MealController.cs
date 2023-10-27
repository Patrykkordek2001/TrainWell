using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpPost("AddMeal")]
        public async Task<ActionResult> AddMeal(MealDto mealDto)
        {
            var newMeal = await _mealService.AddMealAsync(mealDto);

            if (newMeal == null) return BadRequest("Błąd podczas dodawania posiłku");
            return Ok(new { message = "Posiłek został dodany" });
        }

        [HttpDelete("{mealId}")]
        public async Task<ActionResult> DeleteMeal(int mealId)
        {
            await _mealService.DeleteMealAsync(mealId);
            return Ok(new { message = "Posiłek został usunięty" });
        }

        [HttpGet("GetMealById/{mealId}")]
        public async Task<ActionResult<Meal>> GetMealById(int mealId)
        {
            var meal = await _mealService.GetMealByIdAsync(mealId);
            if (meal == null)
                return NotFound("Posiłek o podanym ID nie istnieje");

            return Ok(meal);
        }

        [HttpGet("GetMealsByDate/{date}")]
        public async Task<ActionResult<List<Meal>>> GetMealsByDate(DateTime date)
        {
            var meals = await _mealService.GetMealsByDateAsync(date);
            if (meals.IsNullOrEmpty()) return NotFound("Brak posiłków w podanej dacie");

            return Ok(meals.ToList());
        }
    }
}
