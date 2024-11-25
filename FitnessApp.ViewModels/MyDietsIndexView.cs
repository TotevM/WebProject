namespace FitnessApp.ViewModels
{
	public class MyDietsIndexView
	{
		public string DietId { get; set; }
		public required string Name { get; set; }
		public required string Description { get; set; } = null!;
		public string? ImageUrl { get; set; }
		public int Calories { get; set; }
		public int? Protein { get; set; }
		public int? Carbohydrates { get; set; }
		public int? Fats { get; set; }
	}
}
