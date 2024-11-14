using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessApp.Data.EntityConfiguration
{
	public class UserWorkoutConfiguration : IEntityTypeConfiguration<UserWorkout>
	{
		public void Configure(EntityTypeBuilder<UserWorkout> builder)
		{
			builder.HasKey(uw => new { uw.WorkoutId, uw.UserId });

			builder.HasOne(uw => uw.Workout)
				.WithMany(w => w.UsersWorkouts)
				.HasForeignKey(uw => uw.WorkoutId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.HasOne(uw => uw.User)
				.WithMany(u => u.UsersWorkouts)
				.HasForeignKey(uw => uw.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			builder.Property(uw => uw.Sets).HasDefaultValue(4);
			builder.Property(uw => uw.Repetitions).HasDefaultValue(10);
		}
	}
}
