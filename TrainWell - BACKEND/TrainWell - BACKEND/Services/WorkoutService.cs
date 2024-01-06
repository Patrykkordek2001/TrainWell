using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos.Workouts;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly ISqlRepository<Workout> _workoutRepository;
        private readonly IMapper _mapper;
        private readonly TrainWellDbContext _context;
        private readonly ICurrentUserProvider _currentUserProvider;

        public WorkoutService(ISqlRepository<Workout> workoutRepository,
                 IMapper mapper, TrainWellDbContext context, ICurrentUserProvider currentUserProvider)
        {
            _context = context;
            _workoutRepository = workoutRepository;
            _mapper = mapper;
            _currentUserProvider = currentUserProvider;
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
            var allWorkouts = await _workoutRepository.GetAllAsync();
            var userId = await _currentUserProvider.GetUserIdAsync();
            var userWorkouts = allWorkouts.Where(x => x.UserId == userId);
            return userWorkouts;
        }

        public async Task<Workout> GetWorkoutByIdAsync(int id)
        {
            var workout = await _context.Workouts.
                Include(w => w.ExercisesWorkout)?.
                ThenInclude(e => e.ExerciseSets)?.
                FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null) return null;
            return workout;
        }

        public async Task UpdateWorkoutAsync(WorkoutUpdateDto workout)
        {
            var userId = await _currentUserProvider.GetUserIdAsync();
            var existingWorkout = await _context.Workouts.
                Include(w => w.ExercisesWorkout)?.
                ThenInclude(e => e.ExerciseSets)?.
                FirstOrDefaultAsync(w => w.Id == workout.Id);

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
                    existingExerciseWorkout.ExerciseSets.Add(exerciseSet);
                }
            }

            foreach (var existingExerciseSet in existingExerciseSets.ToList())
            {
                if (!exerciseSets.Any(e => e.Id == existingExerciseSet.Id))
                {
                    existingExerciseWorkout.ExerciseSets.Remove(existingExerciseSet);
                }
            }
        }
    }
}