using System.Text.Json;
using FitnessApp.Data.Models;
using FitnessApp.Data.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static FitnessApp.Common.EntityValidationConstants.DietValidation;

namespace FitnessApp.Data.EntityConfiguration
{
	public class DietConfiguration : IEntityTypeConfiguration<Diet>
	{
		public void Configure(EntityTypeBuilder<Diet> builder)
		{
			builder.HasKey(d => d.Id);

			builder.Property(d => d.Name)
				.IsRequired();

			builder.Property(d => d.Description)
				.IsRequired();

			builder.Property(d => d.UserID)
				.IsRequired(false);

			builder.HasMany(d => d.DietsRecipes)
				.WithOne(df => df.Diet)
				.HasForeignKey(df => df.DietId)
				.OnDelete(DeleteBehavior.Cascade);

            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FitnessApp.Data", "Datasets", "diets.json");
            string data = File.ReadAllText(path);
            var diets = JsonSerializer.Deserialize<List<Diet>>(data);

            if (diets != null)
            {
                foreach (var diet in diets)
                {
                    diet.Calories = 0;
                    diet.Protein = 0;
                    diet.Carbohydrates = 0;
                    diet.Fats = 0;

                    builder.HasData(diet);
                }
            }
        }
    }
}
