using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.Data.Models
{
	public class UserWorkout
	{
		public Guid WorkoutId { get; set; }

		[ForeignKey(nameof(WorkoutId))]
		public virtual Workout Workout { get; set; } = null!;

		public string UserId { get; set; }

		[ForeignKey(nameof(UserId))]
		public virtual ApplicationUser User { get; set; } = null!;

		[Required]
		public int Sets { get; set; }
		[Required]
		public int Repetitions { get; set; }
	}
}
