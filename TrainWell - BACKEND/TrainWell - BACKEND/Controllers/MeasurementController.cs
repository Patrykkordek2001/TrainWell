using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;

namespace TrainWell___BACKEND.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementService _measurementService;


        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }
        [HttpPost("AddMeasurement")]
        public async Task<ActionResult> AddMeasurement(MeasurementsDto measurementDto)
        {
            var newMeasurement = await _measurementService.AddMeasurementAsync(measurementDto);

            if (newMeasurement == null) return BadRequest("Błąd podczas dodawania pomiaru");
            return Ok(new { message = "Pomiar został dodany" });
        }

        [HttpDelete("{measurementId}")]
        public async Task<ActionResult> DeleteMeasurement(int measurementId)
        {
            await _measurementService.DeleteMeasurementAsync(measurementId);
            return Ok(new { message = "Pomiar został usunięty" });

        }

        [HttpGet("GetMeasurementById/{measurementId}")]
        public async Task<ActionResult<Measurement>> GetMeasurementById(int measurementId)
        {
            var measurements = await _measurementService.GetMeasurementByIdAsync(measurementId);
            if (measurements == null)
                return NotFound("Pomiar o podanym ID nie istnieje");

            return Ok(measurements);
        }

        [HttpGet("GetMeasurementByDate/{date}")]
        public async Task<ActionResult<List<Measurement>>> GetMeasurementByDate(DateTime date)
        {
            var measurements = await _measurementService.GetMeasurementByDateAsync(date);
            if (measurements.IsNullOrEmpty()) return NotFound("Brak pomiarów w podanej dacie");

            return Ok(measurements.ToList());
        }

        [HttpGet("GetAllMeasurements")]
        public async Task<ActionResult<List<Measurement>>> GetAllMeasurements()
        {
            var measurements = await _measurementService.GetAllMeasurementsAsync();
            if (measurements.IsNullOrEmpty()) return NotFound("Brak pomiarów w systemie!");

            return Ok(measurements.ToList());
        }
    }
}
