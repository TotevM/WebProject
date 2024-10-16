using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
	{
		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.HasKey(e => e.Id);

			builder.Property(e => e.Name)
				.IsRequired();

			builder.Property(e => e.Difficulty)
				.IsRequired();

			builder.HasMany(e => e.WorkoutsExercises)
				.WithOne(we => we.Exercise)
				.HasForeignKey(we => we.ExerciseId);
		}
	}
}