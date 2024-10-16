using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class DietFoodConfiguration : IEntityTypeConfiguration<DietFood>
	{
		public void Configure(EntityTypeBuilder<DietFood> builder)
		{
			builder.HasKey(df => new { df.DietId, df.FoodId });

			builder.HasOne(df => df.Diet)
				.WithMany(d => d.DietsFoods)
				.HasForeignKey(df => df.DietId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(df => df.Food)
				.WithMany(f => f.DietsFoods)
				.HasForeignKey(df => df.FoodId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}