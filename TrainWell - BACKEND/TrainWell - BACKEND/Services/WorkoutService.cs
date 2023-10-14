using AutoMapper;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class WorkoutService 
    {

        private readonly ISqlRepository<Workout> _workoutRepository;
        private readonly IMapper _mapper;
        public WorkoutService(ISqlRepository<Workout> workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task AddWorkoutAsync(WorkoutDto workout)
        {
            var workoutModel = _mapper.Map<Workout>(workout);



            await _workoutRepository.AddAsync(workoutModel);
        }

        public async Task DeleteWorkoutAsync(Guid id)
        {
            await _workoutRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {
            return await _workoutRepository.GetAllAsync();
        }

        public async Task<Workout> GetWorkoutByIdAsync(Guid id)
        {
            return await _workoutRepository.GetByIdAsync(id);
        }

        public async Task UpdateWorkoutAsync(Workout workout)
        {
            await _workoutRepository.UpdateAsync(workout);
        }

    }
}
