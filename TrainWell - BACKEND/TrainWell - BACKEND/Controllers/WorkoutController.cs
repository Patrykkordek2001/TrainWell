﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;


        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
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
             await _workoutService.DeleteWorkoutAsync(workoutId);
             return Ok(new { message = "Trening został usunięty" });
              
        }

        [HttpGet("GetWorkoutByID/{workoutId}")]
        public async Task<ActionResult<Workout>> GetWorkoutByID(int workoutId)
        {
            var workout = await _workoutService.GetWorkoutByIdAsync(workoutId);
            if (workout == null)
                return NotFound("Trening o podanym ID nie istnieje");

            return Ok(workout);
        }

        [HttpGet("GetWorkoutByDate/{date}")]
        public async Task<ActionResult<List<Workout>>> GetWorkoutByDate(DateTime date)
        {
            var workouts = await _workoutService.GetWorkoutByDateAsync(date);
            if (workouts.IsNullOrEmpty() ) return NotFound("Brak treningów w podanej dacie");

            return Ok(workouts.ToList());
        }
    }
}






        

    

