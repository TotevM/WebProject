using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
    public class UserDietConfiguration : IEntityTypeConfiguration<UserDiet>
    {
        public void Configure(EntityTypeBuilder<UserDiet> builder)
        {
            builder.HasKey(ud => new{ud.UserId, ud.DietId});
        }
    }
}
