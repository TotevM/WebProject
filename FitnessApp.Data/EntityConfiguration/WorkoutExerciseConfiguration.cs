using System.Text.Json;
using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
    public class WorkoutExerciseConfiguration : IEntityTypeConfiguration<WorkoutExercise>
	{
		public void Configure(EntityTypeBuilder<WorkoutExercise> builder)
		{
			builder.HasKey(we => new { we.WorkoutId, we.ExerciseId });

			builder.HasOne(we => we.Workout)
				.WithMany(w => w.WorkoutsExercises)
				.HasForeignKey(we => we.WorkoutId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(we => we.Exercise)
				   .WithMany(e => e.WorkoutsExercises)
				   .HasForeignKey(we => we.ExerciseId)
				   .OnDelete(DeleteBehavior.Cascade);

			builder.Property(uw => uw.IsDeleted).HasDefaultValue(false);

            builder.Property(uw => uw.Sets).HasDefaultValue(4);
            builder.Property(uw => uw.Repetitions).HasDefaultValue(10);

            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FitnessApp.Data", "Datasets", "workoutExercise.json");
            string data = File.ReadAllText(path);
            var workoutsExercises = JsonSerializer.Deserialize<List<WorkoutExercise>>(data);

            if (workoutsExercises != null)
            {
                builder
                    .HasData(workoutsExercises);
            }
        }
	}
}
