using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TrainWell___BACKEND.Dtos;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class WorkoutService //: IWorkoutService
    {

        private readonly ISqlRepository<Workout> _workoutRepository;
        private readonly ISqlRepository<Exercise> _exerciseRepository;
        private readonly ISqlRepository<ExerciseSet> _exerciseSetRepository;
        private readonly IMapper _mapper;
        public WorkoutService(ISqlRepository<Workout> workoutRepository, ISqlRepository<Exercise> exerciseRepository, ISqlRepository<ExerciseSet> exerciseSetRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _exerciseSetRepository = exerciseSetRepository;
            _mapper = mapper;
        }

        //public async Task<int> AddWorkoutAsync(WorkoutDto workout)
        //{
        //    var workoutModel = _mapper.Map<Workout>(workout);
        //
        //    await _workoutRepository.AddAsync(workoutModel);
        //
        //    foreach (var exercise in workoutModel.Exercises)
        //    {
        //       // exercise.WorkoutId = workoutModel.Id;
        //        await _exerciseRepository.AddAsync(exercise);
        //
        //        foreach (var set in exercise.ExerciseSets)
        //        {
        //           // set.ExerciseId = exercise.Id;
        //            await _exerciseSetRepository.AddAsync(set);
        //        }
        //    }
        //
        //    return workoutModel.Id;
        //
        //}

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
