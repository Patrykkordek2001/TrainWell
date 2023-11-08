using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost("AddExercise")]
        public async Task<ActionResult> AddExercise(ExerciseDto productDto)
        {
            var newProduct = await _exerciseService.AddExerciseAsync(productDto);

            if (newProduct == null) return BadRequest("Błąd podczas dodawania produktu");
            return Ok(new { message = "Ćwiczenie zostało dodane" });
        }

        [HttpDelete("{exerciseId}")]
        public async Task<ActionResult> DeleteExercise(int exerciseId)
        {
            await _exerciseService.DeleteExerciseAsync(exerciseId);
            return Ok(new { message = "Ćwiczenie zostało usunięty" });
        }

        [HttpGet("GetExerciseById/{exerciseId}")]
        public async Task<ActionResult<Exercise>> GetExerciseById(int productId)
        {
            var product = await _exerciseService.GetExerciseByIdAsync(productId);
            if (product == null)
                return NotFound("Ćwiczenie o podanym ID nie istnieje");

            return Ok(product);
        }
    }
}
