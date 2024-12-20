﻿using System.ComponentModel.DataAnnotations;
using FitnessApp.Common.Enumerations;
using static FitnessApp.Common.EntityValidationConstants.RecipeValidation;

namespace FitnessApp.ViewModels.RecipeModels
{
    public class AddRecipeView
    {
        [MinLength(RecipeNameMinLength)]
        [MaxLength(RecipeNameMaxLength)]
        [Required]
        public string RecipeName { get; set; } = null!;

        [MinLength(PreparationNameMinLength)]
        [MaxLength(PreparationNameMaxLength)]
        [Required]
        public string Preparation { get; set; } = null!;

        [MinLength(IngredientsNameMinLength)]
        [MaxLength(IngredientsNameMaxLength)]
        [Required]
        public string Ingredients { get; set; } = null!;

        [RegularExpression(@"^(https?:\/\/.*\.(jpg|jpeg|png|gif|bmp|webp))$",
    ErrorMessage = "Enter a valid image URL or leave it blank!")]
        public string? ImageUrl { get; set; }

        [Required]
        public string Goal { get; set; } = null!;

        [Range(0, CalsMax)]
        [Required]
        public int? Calories { get; set; }
        [Range(0, ProteinMax)]
        [Required]
        public int? Protein { get; set; }
        [Range(0, CarbsMax)]
        [Required]
        public int? Carbohydrates { get; set; }
        [Range(0, FatsMax)]
        [Required]
        public int? Fats { get; set; }
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    }
}
