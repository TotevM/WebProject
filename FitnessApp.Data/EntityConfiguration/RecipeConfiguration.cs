using System.Text.Json;
using FitnessApp.Data.Models;
using FitnessApp.Data.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
	{
		public void Configure(EntityTypeBuilder<Recipe> builder)
		{
			builder.HasKey(r => r.Id);

			builder.Property(r => r.Name)
				   .IsRequired();

			builder.Property(r => r.Ingredients)
				   .IsRequired();

			builder.Property(r => r.Preparation)
				   .IsRequired();

			builder.Property(r => r.UserID)
				   .IsRequired(false);

            string path = Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "FitnessApp.Data", "Datasets", "recipes.json");
            string data = File.ReadAllText(path);
            var recipes = JsonSerializer.Deserialize<List<Recipe>>(data);

            if (recipes != null)
            {
                builder
                    .HasData(recipes);
            }
		}
	}
}
