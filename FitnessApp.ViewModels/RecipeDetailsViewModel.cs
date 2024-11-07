namespace FitnessApp.ViewModels
{
    using System;

    public class RecipeDetailsViewModel
    {
        public Guid Id { get; set; }             // Unique identifier for the recipe
        //public string DietId { get; set; }
        public string Name { get; set; }          // Name of the recipe
        public int Calories { get; set; }         // Total calories for the recipe
        public int Protein { get; set; }          // Amount of protein in grams
        public int Carbohydrates { get; set; }    // Amount of carbohydrates in grams
        public int Fats { get; set; }             // Amount of fats in grams
        public string ImageUrl { get; set; }      // URL of the image for the recipe
        public string Ingredients { get; set; }   // Ingredients as a single string
        public string Preparation { get; set; }   // Preparation instructions
        public string UserId { get; set; }
	}

}
