using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.User;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class WorkoutService : IWorkoutService
    {

        private readonly ISqlRepository<Workout> _workoutRepository;
        private readonly ISqlRepository<ExerciseWorkout> _exerciseWorkoutRepository;
        private readonly ISqlRepository<Exercise> _exerciseRepository;
        private readonly ISqlRepository<ExerciseSet> _exerciseSetRepository;
        private readonly IMapper _mapper;
        private readonly TrainWellDbContext _context;
        private readonly ICurrentUserProvider _currentUserProvider;

        public WorkoutService(ISqlRepository<Workout> workoutRepository, ISqlRepository<Exercise> exerciseRepository, ISqlRepository<ExerciseSet> exerciseSetRepository,
            IMapper mapper, TrainWellDbContext context, ICurrentUserProvider currentUserProvider, ISqlRepository<ExerciseWorkout> exerciseWorkoutRepository)
        {
            _context = context;
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseSetRepository = exerciseSetRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
            _exerciseWorkoutRepository = exerciseWorkoutRepository;
        }

        public async Task<int> AddWorkoutAsync(WorkoutDto workout)
        {
            var workoutModel = _mapper.Map<Workout>(workout);
            var userId = await _currentUserProvider.GetUserIdAsync();
            workoutModel.UserId = userId;
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
            var workout = await _context.Workouts.Include(w => w.ExercisesWorkout)?.ThenInclude(e => e.ExerciseSets).FirstOrDefaultAsync(w => w.Id == id);
            return  workout;
        }


        public async Task UpdateWorkoutAsync(WorkoutUpdateDto workout)
        {
            var workoutModel = _mapper.Map<Workout>(workout);
            var userId = await _currentUserProvider.GetUserIdAsync();
            workoutModel.UserId = userId;
            await _workoutRepository.UpdateAsync(workoutModel);
        }

        public async Task UpdateWorkoutAsync2(WorkoutUpdateDto workout)
        {
            var userId = await _currentUserProvider.GetUserIdAsync();
            var existingWorkout = await _context.Workouts.
                Include(w => w.ExercisesWorkout)?.
                ThenInclude(e => e.ExerciseSets).
                FirstOrDefaultAsync(w => w.Id == workout.Id); ;

            if (existingWorkout == null)
            {          
                return;
            }

            if (existingWorkout.UserId != userId)
            {
                return;
            }

            existingWorkout.Title = workout.Title;
            existingWorkout.Date = workout.Date;
            

            await UpdateExerciseWorkouts(existingWorkout, workout.ExercisesWorkout);

            // Zapisz zmiany w bazie danych
            await _workoutRepository.UpdateAsync(existingWorkout);
        }

        private async Task UpdateExerciseWorkouts(Workout existingWorkout, ICollection<ExerciseWorkout> exerciseWorkouts)
        {
            var existingExerciseWorkouts = existingWorkout.ExercisesWorkout.ToList();
            foreach (var exerciseWorkout in exerciseWorkouts)
            {
                var existingExerciseWorkout = existingExerciseWorkouts.FirstOrDefault(e => e.Id == exerciseWorkout.Id);
                if (existingExerciseWorkout != null)
                {
                    existingExerciseWorkout.ExerciseId = exerciseWorkout.ExerciseId;
                    existingExerciseWorkout.WorkoutId = exerciseWorkout.WorkoutId;
                    await UpdateExerciseSets(existingExerciseWorkout, exerciseWorkout.ExerciseSets);
                }
                else
                {
                    //var newExWorkout = new ExerciseWorkout
                    //{
                    //    Id = exerciseWorkout.Id,
                    //    WorkoutId = exerciseWorkout.WorkoutId,
                    //    ExerciseId = exerciseWorkout.ExerciseId,
                    //    ExerciseSets = exerciseWorkout.ExerciseSets
                    //};
                    existingWorkout.ExercisesWorkout.Add(exerciseWorkout);

                }
            }

            foreach (var existingExerciseWorkout in existingExerciseWorkouts)
            {
                if (!exerciseWorkouts.Any(e => e.Id == existingExerciseWorkout.Id))
                {
                    existingWorkout.ExercisesWorkout.Remove(existingExerciseWorkout);
                }
            }
        }

        private async Task UpdateExerciseSets(ExerciseWorkout existingExerciseWorkout, ICollection<ExerciseSet> exerciseSets)
        {
            var existingExerciseSets = existingExerciseWorkout.ExerciseSets.ToList();

            foreach (var exerciseSet in exerciseSets)
            {
                var existingExerciseSet = existingExerciseSets.FirstOrDefault(e => e.Id == exerciseSet.Id);

                if (existingExerciseSet != null)
                {
                    existingExerciseSet.Weight = exerciseSet.Weight;
                    existingExerciseSet.Repetitions = exerciseSet.Repetitions;
                    existingExerciseSet.ExerciseWorkoutId = exerciseSet.ExerciseWorkoutId;
                }
                else
                {
                    //var newExSet = new ExerciseSet()
                    //{
                    //    Id= exerciseSet.Id,
                    //    Weight= exerciseSet.Weight,
                    //    Repetitions = exerciseSet.Repetitions,
                    //    ExerciseWorkoutId = exerciseSet.ExerciseWorkoutId
                    //
                    //};
                    existingExerciseWorkout.ExerciseSets.Add(exerciseSet);
                    //existingExerciseSets.Add(exerciseSet); 
                    // Add the new exercise set to the existing collection
                }
            }

            // Remove exercise sets that are not in the updated list
            foreach (var existingExerciseSet in existingExerciseSets.ToList())
            {
                if (!exerciseSets.Any(e => e.Id == existingExerciseSet.Id))
                {
                    existingExerciseWorkout.ExerciseSets.Remove(existingExerciseSet);
                    // Remove from the context if needed: await _exerciseSetRepository.DeleteAsync(existingExerciseSet.Id);
                }
            }
        }


        //public async Task<ExerciseWorkout> AddExerciseWorkoutAsync(ExerciseWorkout exerciseWorkout)
        //{
        //
        //    await _exerciseWorkoutRepository.AddAsync(exerciseWorkout);
        //
        //    return exerciseWorkout;
        //
        //}
        //public async Task<ExerciseSet> AddExerciseSetAsync(ExerciseSet exerciseSet)
        //{
        //    await _exerciseSetRepository.AddAsync(exerciseSet);
        //
        //    return exerciseSet;
        //
        //}


    }
}
