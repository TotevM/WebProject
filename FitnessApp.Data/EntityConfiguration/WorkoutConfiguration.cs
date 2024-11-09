using System.Text.Json;
using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
    public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
	{
		public void Configure(EntityTypeBuilder<Workout> builder)
		{
			builder.HasKey(w => w.Id);

			builder.Property(w => w.Name)
				   .IsRequired();

			builder.Property(w => w.UserID)
				   .IsRequired(false);

			builder.HasMany(w => w.WorkoutsExercises)
				   .WithOne(we => we.Workout)
				   .HasForeignKey(we => we.WorkoutId);

            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FitnessApp.Data", "Datasets", "workouts.json");
            string data = File.ReadAllText(path);
            var workouts = JsonSerializer.Deserialize<List<Workout>>(data);

            if (workouts != null)
            {
                builder
                    .HasData(workouts);
            }
        }
	}
}
