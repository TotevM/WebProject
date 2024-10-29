using FitnessApp.Data.EntityConfiguration;
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

            builder.ApplyConfiguration(new DietConfiguration());
            builder.ApplyConfiguration(new DietFoodConfiguration());
            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new FoodConfiguration());
            builder.ApplyConfiguration(new ProgressConfiguration());
            builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
            builder.ApplyConfiguration(new WorkoutExerciseConfiguration());
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
