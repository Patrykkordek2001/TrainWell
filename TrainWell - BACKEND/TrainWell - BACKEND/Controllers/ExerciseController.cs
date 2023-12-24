using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpPost("AddExercise")]
        public async Task<ActionResult<Exercise>> AddExercise(ExerciseDto productDto)
        {
            var newExercise = await _exerciseService.AddExerciseAsync(productDto);

            
            return newExercise;
        }

        [HttpDelete("DeleteExerciseById/{exerciseId}")]
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

        [HttpGet("GetAllExercises")]
        public async Task<ActionResult<List<Exercise>>> GetAllExercises(int productId)
        {
            var exercises = await _exerciseService.GetAllExercisesAsync();
            if (exercises.Count() <= 0 )
                return Ok("Lista ćwiczeń jest pusta");

            return exercises.ToList();
        }


    }
}
