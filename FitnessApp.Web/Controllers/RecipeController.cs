﻿using System.Security.Claims;
using FitnessApp.Common.Enumerations;
using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FitnessApp.Web.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(Goal? goal = null)
        {
            var model = await recipeService.DisplayDietsAsync(goal);
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = recipeService.AddRecipe();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeView model)
        {
            if (!ModelState.IsValid)
            {
                var filledGoals = recipeService.AddRecipe();
                model.Goals = filledGoals.Goals;
                return View(model);
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await recipeService.AddRecipeAsync(model, goal, userId);

            return RedirectToAction("Index", "Recipe");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var recipeModel = await recipeService.EditView(id);
            return View(recipeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var filledGoals = recipeService.AddRecipe();
                model.Goals = filledGoals.Goals;

                return View(model);
            }

            Recipe? recipe = await recipeService.GetRecipeAsync(model.Id);

            if (recipe == null)
            {
                return NotFound();
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            await recipeService.UpdateRecipe(recipe, model, goal);
            await recipeService.UpdateDietsAsync(model.Id);

            return RedirectToAction("Index", "Recipe");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var recipe = await recipeService.GetRecipeAsync(id);

            if (recipe == null)
            {
                return NotFound();
            }

            var viewModel = recipeService.RecipeDetailsView(recipe);
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var recipe = await recipeService.GetRecipeAsync(id);

            if (recipe == null)
            {
                return NotFound("Recipe not found");
            }

            var model = recipeService.DeleteView(recipe);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRecipeView model)
        {
            var recipe = await recipeService.GetRecipeAsync(model.Id);

            if (recipe == null)
            {
                return NotFound();
            }

            await recipeService.SoftDeleteRecipe(recipe!);
            await recipeService.DeleteDietRecipeRelationAsync(model.Id);
            await recipeService.UpdateDietsAsync(model.Id);
            return RedirectToAction("Index", "Recipe");
        }
    }
}
