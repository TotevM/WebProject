using FitnessApp.Data.Models;
using FitnessApp.Data.Models.Models;
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
				   .IsRequired();

			builder.HasMany(w => w.WorkoutsExercises)
				   .WithOne(we => we.Workout)
				   .HasForeignKey(we => we.WorkoutId);
		}
	}
}
