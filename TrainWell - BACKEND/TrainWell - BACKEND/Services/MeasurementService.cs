using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class MeasurementService : IMeasurementService
    {

        private readonly ISqlRepository<Measurement> _measurementRepository;
        private readonly IMapper _mapper;
        private readonly TrainWellDbContext _context;


        public MeasurementService(ISqlRepository<Measurement> measurementRepository, IMapper mapper, TrainWellDbContext context)
        {
            _measurementRepository = measurementRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<int> AddMeasurementAsync(MeasurementsDto measurementDto)
        {
            var measurementModel = _mapper.Map<Measurement>(measurementDto);

            await _measurementRepository.AddAsync(measurementModel);

            return measurementModel.Id;

        }

        public async Task DeleteMeasurementAsync(int id)
        {
            await _measurementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Measurement>> GetAllMeasurementsAsync()
        {
            return await _measurementRepository.GetAllAsync();
        }

        public async Task<Measurement> GetMeasurementByIdAsync(int id)
        {
            return await _measurementRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Measurement>> GetMeasurementByDateAsync(DateTime date)
        {
            var measurements = _context.Measurements
                    .Where(w => w.Date.Date == date.Date);

            return measurements;
        }


        public async Task UpdateMeasurementAsync(Measurement measurement)
        {
            await _measurementRepository.UpdateAsync(measurement);
        }

    }
}
