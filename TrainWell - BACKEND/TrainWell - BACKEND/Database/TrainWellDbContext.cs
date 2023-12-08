using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrainWell___BACKEND.Models;
using TrainWell___BACKEND.Models.Diet;
using TrainWell___BACKEND.Models.Training;
using TrainWell___BACKEND.Models.User;

namespace TrainWell___BACKEND.Database
{
    public class TrainWellDbContext : DbContext
    {
        public TrainWellDbContext(DbContextOptions<TrainWellDbContext> options) : base(options) { }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealProduct> ProductsInMeal { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

    }
}
