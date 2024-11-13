using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Data.EntityConfiguration
{
	public class UserDietConfiguration : IEntityTypeConfiguration<UserDiet>
	{
		public void Configure(EntityTypeBuilder<UserDiet> builder)
		{
			builder.HasKey(ud => new
			{
				ud.UserId,
				ud.DietId
			});
		}
	}
}
