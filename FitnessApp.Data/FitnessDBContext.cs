using FitnessApp.Data.EntityConfiguration;
using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class FitnessDBContext : IdentityDbContext<ApplicationUser>
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
               : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RecipeConfiguration());
            builder.ApplyConfiguration(new DietConfiguration());
            builder.ApplyConfiguration(new DietRecipeConfiguration());
            builder.ApplyConfiguration(new UserDietConfiguration());

            builder.ApplyConfiguration(new ExerciseConfiguration());
            builder.ApplyConfiguration(new WorkoutConfiguration());
            builder.ApplyConfiguration(new WorkoutExerciseConfiguration());
            builder.ApplyConfiguration(new UserWorkoutConfiguration());

            builder.ApplyConfiguration(new ProgressConfiguration());
        }

        public async Task SeedDatabaseAsync()
        {
            var diets = await Diets.ToListAsync();
            foreach (var diet in diets)
            {
                diet.Calories = diet.DietsRecipes.Sum(df => df.Recipe.Calories);
                diet.Protein = diet.DietsRecipes.Sum(df => df.Recipe.Protein);
                diet.Carbohydrates = diet.DietsRecipes.Sum(df => df.Recipe.Carbohydrates);
                diet.Fats = diet.DietsRecipes.Sum(df => df.Recipe.Fats);
            }

            await SaveChangesAsync();
        }

        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<Diet> Diets { get; set; } = null!;
        public DbSet<DietRecipe> DietsRecipes { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Progress> Progresses { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; } = null!;
        public DbSet<UserDiet> UsersDiets { get; set; } = null!;
        public DbSet<UserWorkout> UsersWorkouts { get; set; } = null!;
    }
}
