using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessApp.Common.Enumerations;

namespace FitnessApp.ViewModels
{
	public class ExerciseIndexView
	{
		public Guid Id { get; set; }
		public required string Name { get; set; }
		public required string Difficulty { get; set; }
		public string? ImageUrl { get; set; }
		public required string MuscleGroup { get; set; }
	}
}
