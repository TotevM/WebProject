using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;

namespace FitnessApp.Services
{
	public class DietService : IDietService
	{
		public Task<List<SelectListItem>> AddRecipeToDiet(Guid recipeId)
		{
			throw new NotImplementedException();
		}

		public Task AddRecipeToDiet(AddRecipeToDietViewModel model)
		{
			throw new NotImplementedException();
		}

		public Task AddToMyDiets(Guid dietId)
		{
			throw new NotImplementedException();
		}

		public Task<List<DietIndexView>> DefaultDietsAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<DietDetailsView>> DietDetails(Guid dietId)
		{
			throw new NotImplementedException();
		}

		public Task<List<MyDietsIndexView>> MyDietsAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<RecipeDetailsInDiet> RecipeDetailsInDietAsync(Guid recipeId, Guid dietId)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromDiet(Guid dietId, Guid recipeId)
		{
			throw new NotImplementedException();
		}

		public Task RemoveFromMyDiets(Guid dietId)
		{
			throw new NotImplementedException();
		}
	}
}
