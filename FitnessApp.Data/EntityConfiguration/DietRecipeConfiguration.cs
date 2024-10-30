using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class DietRecipeConfiguration : IEntityTypeConfiguration<DietRecipe>
	{
		public void Configure(EntityTypeBuilder<DietRecipe> builder)
		{
			builder.HasKey(df => new { df.DietId, df.RecipeId });

			builder.HasOne(df => df.Diet)
				.WithMany(d => d.DietsRecipes)
				.HasForeignKey(df => df.DietId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(df => df.Recipe)
				.WithMany(f => f.DietsRecipes)
				.HasForeignKey(df => df.RecipeId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}