using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class FoodConfiguration : IEntityTypeConfiguration<Food>
	{
		public void Configure(EntityTypeBuilder<Food> builder)
		{
			builder.HasKey(f => f.Id);

			builder.Property(f => f.Name)
				   .IsRequired();

			builder.Property(f => f.Calories)
				   .IsRequired();

			builder.Property(f => f.Protein)
				   .IsRequired();

			builder.Property(f => f.Carbs)
				   .IsRequired();

			builder.Property(f => f.Fats)
				   .IsRequired();

			builder.HasMany(f => f.DietsFoods)
				   .WithOne(df => df.Food)
				   .HasForeignKey(df => df.FoodId);
		}
	}
}
