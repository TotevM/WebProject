using System.Web.Mvc;
using FitnessApp.Data.Repository.Contracts;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Services
{
	public class DietService : BaseService, IDietService
	{

		private readonly IRepository<Diet, Guid> dietRepository;
		private readonly IRepository<Recipe, Guid> recipeRepository;

		public DietService(IRepository<Diet, Guid> dietRepository, IRepository<Recipe, Guid> recipeRepository)
		{
			this.dietRepository = dietRepository;
			this.recipeRepository = recipeRepository;
		}

		public Task<List<SelectListItem>> AddRecipeToDietAsync(Guid recipeId)
		{
			throw new NotImplementedException();
		}

		public Task AddRecipeToDietAsync(AddRecipeToDietViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task AddToMyDietsAsync(Guid dietId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<DietIndexView>> DefaultDietsAsync(string userId)
		{
			var diets = await dietRepository.GetAllAttached()
				.Where(d => !d.UserDiets.Any(ud => ud.UserId == userId) && d.UserID == null)
				.Select(diet => new DietIndexView
			{
				DietId = diet.Id,
				Name = diet.Name,
				Description = diet.Description,
				ImageUrl = diet.ImageUrl,
				Calories = diet.Calories,
				Protein = diet.Protein,
				Carbohydrates = diet.Carbohydrates,
				Fats = diet.Fats
			}).ToListAsync();

			return diets;
		}//completed

		public async Task<List<DietDetailsView>> DietDetailsAsync(Guid dietId)
		{
            var recipes = await recipeRepository.GetAllAttached().Where(r => r.DietsRecipes.Any(d => d.DietId == dietId))
				.Select(recipe => new DietDetailsView
			{
				DietId = dietId,
				RecipeId = recipe.Id,
				Name = recipe.Name,
				ImageUrl = recipe.ImageUrl,
				Calories = recipe.Calories,
				Protein = recipe.Protein,
				Carbohydrates = recipe.Carbohydrates,
				Fats = recipe.Fats
			}).ToListAsync();

			return recipes;
		}//completed

		public async Task<List<MyDietsIndexView>> MyDietsAsync(string userId)
		{
			var diets = await dietRepository.GetAllAttached()
				.Where(d => d.UserDiets.Any(ud => ud.UserId == userId))
				.Select(diet => new MyDietsIndexView
				{
					DietId = diet.Id,
					Name = diet.Name,
					Description = diet.Description,
					ImageUrl = diet.ImageUrl,
					Calories = diet.Calories,
					Protein = diet.Protein,
					Carbohydrates = diet.Carbohydrates,
					Fats = diet.Fats
				}).ToListAsync();

			return diets;
		}//completed

		public Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromDietAsync(Guid dietId, Guid recipeId)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromMyDietsAsync(Guid dietId)
		{
			throw new NotImplementedException();
		}
	}
}
