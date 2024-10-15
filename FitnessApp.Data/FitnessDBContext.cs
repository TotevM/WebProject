using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class FitnessDBContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Progress>()
                .Property(p => p.Weight)
                .HasPrecision(18, 2);

            builder.Entity<Workout>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);


            builder.Entity<DietFood>().HasKey(df => new { df.DietId, df.FoodId });
            builder.Entity<WorkoutExercise>().HasKey(we => new { we.WorkoutId, we.ExerciseId });
        }
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<Diet> Diets { get; set; } = null!;
        public DbSet<DietFood> DietsFoods { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Progress> Progresses { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; } = null!;
    }
}
