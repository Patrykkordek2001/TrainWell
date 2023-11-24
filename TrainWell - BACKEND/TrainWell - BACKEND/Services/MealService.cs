using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainWell___BACKEND.Database;
using TrainWell___BACKEND.Dtos.Diet;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Services.Interfaces;
using TrainWell___BACKEND.SqlRepository;

namespace TrainWell___BACKEND.Services
{
    public class MealService : IMealService
    {
        private readonly ISqlRepository<Meal> _mealRepository;
        private readonly IMapper _mapper;
        private readonly TrainWellDbContext _context;
        private ICurrentUserProvider _currentUserProvider;

        public MealService(ISqlRepository<Meal> mealRepository, IMapper mapper, TrainWellDbContext context, ICurrentUserProvider currentUserProvider)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
            _context = context;
            _currentUserProvider = currentUserProvider; 
        }

        public async Task<int> AddMealAsync(MealDto mealDto)
        {
            var mealModel = _mapper.Map<Meal>(mealDto);
            await _mealRepository.AddAsync(mealModel);

            return mealModel.Id;
        }

        public async Task DeleteMealAsync(int id)
        {
            await _mealRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Meal>> GetAllMealsAsync()
        {
            var allMeals = await _mealRepository.GetAllAsync();
            var userId = await _currentUserProvider.GetUserIdAsync();
            var userMeals = allMeals.Where(x => x.UserId == userId);
            return userMeals;
        }

        public async Task<Meal> GetMealByIdAsync(int id)
        {
            return await _mealRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Meal>> GetMealsByDateAsync(DateTime date)
        {
            var meals = _context.Meals
                .Where(m => m.Date.Date == date.Date);

            return meals;
        }

        public async Task UpdateMealAsync(Meal meal)
        {
            await _mealRepository.UpdateAsync(meal);
        }
    }
}
