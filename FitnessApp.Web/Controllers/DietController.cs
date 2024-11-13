﻿using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Web.Controllers
{
	public class DietController : Controller
	{
		private readonly ILogger<RecipeController> logger;
		private readonly UserManager<ApplicationUser> user;
		private readonly FitnessDBContext context;

		public DietController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
		{
			logger = _logger;
			user = _user;
			context = _context;
		}

		public IActionResult MyDiets()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var diets = context.Diets
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
				}).ToList();

			return View(diets);
		}

		public async Task<IActionResult> Index()
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var diets = context.Diets.Where(d=>!d.UserDiets.Any(ud=>ud.UserId==userId)).ToList();

			var dietViewModels = diets.Select(diet => new DietIndexView
			{
				DietId = diet.Id,
				Name = diet.Name,
				Description = diet.Description,
				ImageUrl = diet.ImageUrl,
				Calories = diet.Calories,
				Protein = diet.Protein,
				Carbohydrates = diet.Carbohydrates,
				Fats = diet.Fats
			}).ToList();

			return View(dietViewModels);
		}

		[HttpGet]
		public async Task<IActionResult> Details(Guid id)
		{
			var recipes = context.Recipes.Where(r => r.DietsRecipes.Any(d => d.DietId == id)).ToList();

			List<DietDetailsView> dietViewModels = recipes.Select(recipe => new DietDetailsView
			{
				DietId = id,
				RecipeId = recipe.Id,
				Name = recipe.Name,
				ImageUrl = recipe.ImageUrl,
				Calories = recipe.Calories,
				Protein = recipe.Protein,
				Carbohydrates = recipe.Carbohydrates,
				Fats = recipe.Fats
			}).ToList();

			return View(dietViewModels);
		}

		[HttpGet]
		public IActionResult DetailsInDiet(Guid recipeId, Guid dietId)
		{
			var recipe = context.Recipes
				.Where(r => r.Id == recipeId)
				.FirstOrDefault();

			if (recipe == null)
			{
				return NotFound();
			}

			var viewModel = new RecipeDetailsInDiet
			{
				DietId = dietId,
				RecipeId = recipeId,
				Name = recipe.Name,
				Calories = recipe.Calories,
				Protein = recipe.Protein,
				Carbohydrates = recipe.Carbohydrates,
				Fats = recipe.Fats,
				ImageUrl = recipe.ImageUrl,
				Ingredients = recipe.Ingredients,
				Preparation = recipe.Preparation
			};

			return View(viewModel);
		}

		public IActionResult RemoveFromDiet(Guid dietId, Guid recipeId)
		{
			var toRemove = context.DietsRecipes
				.Where(x => x.RecipeId == recipeId && x.DietId == dietId)
				.FirstOrDefault();

			if (toRemove != null)
			{
				context.DietsRecipes.Remove(toRemove);

				var diet = context.Diets
					.Include(d => d.DietsRecipes)
					.ThenInclude(dr => dr.Recipe)
					.FirstOrDefault(d => d.Id == dietId);

				if (diet != null)
				{
					diet.Calories = diet.DietsRecipes.Sum(df => df.Recipe.Calories);
					diet.Protein = diet.DietsRecipes.Sum(df => df.Recipe.Protein);
					diet.Carbohydrates = diet.DietsRecipes.Sum(df => df.Recipe.Carbohydrates);
					diet.Fats = diet.DietsRecipes.Sum(df => df.Recipe.Fats);
				}

				context.SaveChanges();
			}

			return RedirectToAction("Details", new { id = dietId });
		}

		[HttpGet]
		public IActionResult AddToDiet(Guid recipeId)
		{
			List<SelectListItem> diets = context.Diets
				.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.Name
				})
				.ToList();

			var viewModel = new AddRecipeToDietViewModel
			{
				RecipeId = recipeId,
				Diets = diets
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult AddToDiet(AddRecipeToDietViewModel model)
		{
			if (ModelState.IsValid)
			{
				var dietRecipe = new DietRecipe
				{
					DietId = model.SelectedDietId,
					RecipeId = model.RecipeId
				};
				;
				context.DietsRecipes.Add(dietRecipe);

				context.SaveChanges();

				var diet = context.Diets
					.Include(d => d.DietsRecipes)
					.ThenInclude(dr => dr.Recipe)
					.FirstOrDefault(d => d.Id == model.SelectedDietId);

				if (diet != null)
				{
					diet.Calories = diet.DietsRecipes
						.Where(df => df.Recipe != null)
						.Sum(df => df.Recipe.Calories);

					diet.Protein = diet.DietsRecipes
						.Where(df => df.Recipe != null)
						.Sum(df => df.Recipe.Protein);

					diet.Carbohydrates = diet.DietsRecipes
						.Where(df => df.Recipe != null)
						.Sum(df => df.Recipe.Carbohydrates);

					diet.Fats = diet.DietsRecipes
						.Where(df => df.Recipe != null)
						.Sum(df => df.Recipe.Fats);
				}

				context.SaveChanges();

				context.SaveChanges();

				return RedirectToAction("Details", new { id = model.SelectedDietId });
			}

			model.Diets = context.Diets
				.Select(d => new SelectListItem
				{
					Value = d.Id.ToString(),
					Text = d.Name
				})
				.ToList();

			return View(model);
		}

		[HttpPost]
		public IActionResult AddToMyDiet(Guid dietId)
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			var model = new UserDiet
			{
				UserId = userId,
				DietId = dietId,
			};

			context.UsersDiets.Add(model);
			context.SaveChanges();

			return RedirectToAction("Index", "Diet");
		}

		public IActionResult RemoveFromMyDiet(Guid dietId)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public IActionResult RemoveFromMyDiets(Guid dietId) 
		{
			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var record = context.UsersDiets.Where(ud => ud.UserId == userId && ud.DietId == dietId).FirstOrDefault();

			if (record==null) 
			{
			//To implement
			}

			context.UsersDiets.Remove(record!);
			context.SaveChanges();

			return RedirectToAction("MyDiets", "Diet");
		}
	}
}
