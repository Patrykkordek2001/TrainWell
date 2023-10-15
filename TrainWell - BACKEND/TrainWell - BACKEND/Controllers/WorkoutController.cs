using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public WorkoutController(IAuthService authService, IConfiguration configuration, IWorkoutService workoutService)
        {
            _workoutService = workoutService;
            _configuration = configuration;
            _authService = authService;

        }
        [HttpPost("AddWorkout")]
        public async Task<ActionResult> AddWorkout(WorkoutDto workoutDto)
        {
            var newWorkout = await _workoutService.AddWorkoutAsync(workoutDto);

            if (newWorkout == null) return BadRequest("Błąd podczas dodawania treningu");
            return Ok(new { message = "Trening został dodany" });
        }

        [HttpDelete("{workoutId}")]
        public async Task<ActionResult> DeleteWorkout(int workoutId)
        {
            // Tutaj wywołaj metodę do usuwania treningu z serwisu lub repozytorium
            var result = await _workoutService.DeleteWorkoutAsync(workoutId);

            if (result)
            {
                return Ok(new { message = "Trening został usunięty" });
            }
            else
            {
                return BadRequest("Błąd podczas usuwania treningu");
            }
        }

    }
}
