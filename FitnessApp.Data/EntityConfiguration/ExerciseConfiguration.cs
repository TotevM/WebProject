using System.Text.Json;
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

            builder.Property(e => e.MuscleGroup)
                .IsRequired();

            builder.Property(e => e.IsDeleted)
                .HasDefaultValue(false);

            builder.HasMany(e => e.WorkoutsExercises)
                .WithOne(we => we.Exercise)
                .HasForeignKey(we => we.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);


            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FitnessApp.Data", "Datasets", "exercises.json");
            string data = File.ReadAllText(path);
            var exercises = JsonSerializer.Deserialize<List<Exercise>>(data)!;

            if (exercises != null)
            {
                builder
                    .HasData(exercises);
            }
        }
    }
}