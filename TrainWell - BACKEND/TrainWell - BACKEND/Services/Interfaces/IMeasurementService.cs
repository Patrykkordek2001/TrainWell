using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Services.Interfaces
{
    public interface IMeasurementService
    {
        Task<int> AddMeasurementAsync(MeasurementsDto measurementDto);
        Task DeleteMeasurementAsync(int id);
        Task<IEnumerable<Measurement>> GetAllMeasurementsAsync();
        Task<Measurement> GetMeasurementByIdAsync(int id);
        Task UpdateMeasurementAsync(Measurement measurement);
        Task<IEnumerable<Measurement>> GetMeasurementByDateAsync(DateTime date);
    }
}