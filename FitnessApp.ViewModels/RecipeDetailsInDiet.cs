namespace FitnessApp.ViewModels
{
	using System;

	public class RecipeDetailsInDiet
	{
		public string RecipeId { get; set; } = null!;
        public string DietId { get; set; } = null!;
		public string Name { get; set; } = null!;
		public int Calories { get; set; }
		public int Protein { get; set; }
		public int Carbohydrates { get; set; }
		public int Fats { get; set; }
		public string ImageUrl { get; set; } = null!;
        public string Ingredients { get; set; } = null!;
        public string Preparation { get; set; } = null!;
        public string UserId { get; set; } = null!;
    }
}