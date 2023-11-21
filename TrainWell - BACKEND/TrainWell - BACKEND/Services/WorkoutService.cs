using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class WorkoutService : IWorkoutService
    {

        private readonly ISqlRepository<Workout> _workoutRepository;
        private readonly ISqlRepository<Exercise> _exerciseRepository;
        private readonly ISqlRepository<ExerciseSet> _exerciseSetRepository;
        private readonly IMapper _mapper;
        private readonly TrainWellDbContext _context;
        private readonly ICurrentUserProvider _currentUserProvider;

        public WorkoutService(ISqlRepository<Workout> workoutRepository, ISqlRepository<Exercise> exerciseRepository, ISqlRepository<ExerciseSet> exerciseSetRepository, IMapper mapper, TrainWellDbContext context, ICurrentUserProvider currentUserProvider)
        {
            _context = context;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseSetRepository = exerciseSetRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
        }

        public async Task<int> AddWorkoutAsync(WorkoutDto workout)
        {
            var workoutModel = _mapper.Map<Workout>(workout);

            await _workoutRepository.AddAsync(workoutModel);

            return workoutModel.Id;

        }

        public async Task DeleteWorkoutAsync(int id)
        {
            await _workoutRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Workout>> GetAllWorkoutsAsync()
        {

            var allWorkouts =  await _workoutRepository.GetAllAsync();
            var userId = await _currentUserProvider.GetUserIdAsync();
            var userWorkouts = allWorkouts.Where(x => x.UserId == userId);
            return userWorkouts;
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            return await _workoutRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Workout>> GetWorkoutByDateAsync(DateTime date)
        {
            var workouts = _context.Workouts
                    .Include(w => w.ExerciseWorkouts) 
                        .ThenInclude(e => e.ExerciseSets)
                    .Where(w => w.Date.Date == date.Date);

            return  workouts;
        }

        public async Task UpdateWorkoutAsync(Workout workout)
        {
            await _workoutRepository.UpdateAsync(workout);
        }

    }
}
