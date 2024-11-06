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
		}
	}
}
