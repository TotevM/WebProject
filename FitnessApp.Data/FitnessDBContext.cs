using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data
{
    public class FitnessDBContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public FitnessDBContext(DbContextOptions<FitnessDBContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Progress>()
                .Property(p => p.Weight)
                .HasPrecision(18, 2);
            
            builder.Entity<Workout>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            base.OnModelCreating(builder);
            //builder.Entity<UserLogin>().HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            builder.Entity<DietFood>().HasKey(df => new { df.DietId, df.FoodId });
            builder.Entity<UserDiet>().HasKey(ud => new { ud.UserId, ud.DietId });
            builder.Entity<UserRecipe>().HasKey(ur => new { ur.UserId, ur.RecipeId });
            builder.Entity<UserWorkout>().HasKey(uw => new { uw.UserId, uw.WorkoutId });
            builder.Entity<WorkoutExercise>().HasKey(we => new { we.WorkoutId, we.ExerciseId });
        }

        public DbSet<Diet> Diets { get; set; } = null!;
        public DbSet<DietFood> DietsFoods { get; set; } = null!;
        public DbSet<Exercise> Exercises { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Progress> Progresses { get; set; } = null!;
        public DbSet<Recipe> Recipes { get; set; } = null!;
        public override DbSet<User> Users { get; set; } = null!;
        public DbSet<UserDiet> UsersDiets { get; set; } = null!;
        public DbSet<UserRecipe> UsersRecipes { get; set; } = null!;
        public DbSet<UserWorkout> UsersWorkouts { get; set; } = null!;
        public DbSet<Workout> Workouts { get; set; } = null!;
        public DbSet<WorkoutExercise> WorkoutsExercises { get; set; } = null!;
    }
}
