using AutoMapper;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ISqlRepository<Exercise> _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(ISqlRepository<Exercise> exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<int> AddExerciseAsync(ExerciseDto productDto)
        {
            var exerciseModel = _mapper.Map<Exercise>(productDto);
            await _exerciseRepository.AddAsync(exerciseModel);

            return exerciseModel.Id;
        }

        public async Task DeleteExerciseAsync(int id)
        {
            await _exerciseRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Exercise>> GetAllExercisesAsync()
        {
            return await _exerciseRepository.GetAllAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id)
        {
            return await _exerciseRepository.GetByIdAsync(id);
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            await _exerciseRepository.UpdateAsync(exercise);
        }
    }
}
