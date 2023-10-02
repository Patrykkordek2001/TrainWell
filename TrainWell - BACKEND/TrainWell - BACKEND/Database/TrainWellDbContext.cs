using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TrainWell___BACKEND.Models;

namespace TrainWell___BACKEND.Database
{
    public class TrainWellDbContext : DbContext
    {
        public TrainWellDbContext(DbContextOptions<TrainWellDbContext> options) : base(options) { }

        public DbSet<Exercise> TrainingEntries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }

    }
}
