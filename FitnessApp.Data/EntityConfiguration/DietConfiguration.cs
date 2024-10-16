using FitnessApp.Data.Models;
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
				.IsRequired();

			builder.HasMany(d => d.DietsFoods)
				.WithOne(df => df.Diet)
				.HasForeignKey(df => df.DietId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
