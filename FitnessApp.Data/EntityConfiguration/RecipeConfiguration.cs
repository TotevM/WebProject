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

			builder.HasData(new Recipe
			{
				Id = Guid.NewGuid(),
				Name = "Scrambled eggs",
				Ingredients = "Eggs, salt",
				Preparation = "Cook the eggs and put salt on them",
				Goal = Goal.FatLoss,
				UserID = null
			}, new Recipe
			{
				Id = Guid.NewGuid(),
				Name = "Eye eggs",
				Ingredients = "Eggs, salt",
				Preparation = "Cook the eggs and put salt on them",
                ImageUrl= "https://sire-media-foxbg.fichub.com/24k_bg/custompage-main/302854.1024x576.jpg",
                Goal = Goal.MassGain,
                UserID = null
			});
		}
	}
}
