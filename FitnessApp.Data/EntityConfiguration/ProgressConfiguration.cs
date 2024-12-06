using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
	{
		public void Configure(EntityTypeBuilder<Progress> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.Date)
				.IsRequired();

			builder.Property(p => p.Weight)
				.IsRequired()
				.HasColumnType("decimal(5,2)")
				.HasPrecision(5, 2);

			builder.Property(p => p.UserID)
				.IsRequired();
		}
	}
}
