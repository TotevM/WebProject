using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.ViewModels.Workout
{
	public class MyWorkoutsView
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public IEnumerable<ExercisesInMyWorkoutsView> Exercises { get; set; } = new List<ExercisesInMyWorkoutsView>();
	}
}
