﻿namespace FitnessApp.ViewModels.RecipeModels
{
    using System;

    public class RecipeDetailsViewModel
	{
        public string RecipeId { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fats { get; set; }
        public string ImageUrl { get; set; }
        public string Ingredients { get; set; }
        public string Preparation { get; set; }
        public string UserId { get; set; }
    }
}