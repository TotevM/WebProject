﻿using System.Globalization;
using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessApp.ViewModels;
using FitnessApp.Common.Enumerations;
using FitnessApp.ViewModels.RecipeModels;


namespace FitnessApp.Web.Controllers
{
    public class RecipeController : Controller
    {
        private readonly ILogger<RecipeController> logger;
        private readonly UserManager<ApplicationUser> user;
        private readonly FitnessDBContext context;

        public RecipeController(ILogger<RecipeController> _logger, UserManager<ApplicationUser> _user, FitnessDBContext _context)
        {
            logger = _logger;
            user = _user;
            context = _context;
        }

        [HttpGet]
        public IActionResult Index(Goal? goal = null)
        {
            var recipesQuery = context.Recipes
                .Where(d => !d.IsDeleted)
                .OrderByDescending(r => r.CreatedOn)
                .ThenBy(d => d.Name)
                .AsQueryable();

            if (goal.HasValue)
            {
                recipesQuery = recipesQuery.Where(r => r.Goal == goal.Value);
            }

            var model = recipesQuery.Select(r => new RecipesIndexView
            {
                Id = r.Id.ToString(),
                ImageUrl = r.ImageUrl,
                Name = r.Name,
                UserID = r.UserID,
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Goal> goals = Enum.GetValues(typeof(Goal))
                .Cast<Goal>()
                .ToList();


            var model = new AddRecipeView()
            {
                Goals = goals,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRecipeView model)
        {
            if (!ModelState.IsValid)
            {
                List<Goal> goals = Enum.GetValues(typeof(Goal))
                    .Cast<Goal>()
                    .ToList();

                model = new AddRecipeView()
                {
                    Goals = goals,
                };
                return View(model);
            }

            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            var recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Name = model.RecipeName,
                CreatedOn = DateTime.Now,
                Preparation = model.Preparation,
                Ingredients = model.Ingredients,
                ImageUrl = model.ImageUrl,
                UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)!,
                Goal = goal,
                Calories = (int)model.Calories!,
                Protein = (int)model.Protein!,
                Carbohydrates = (int)model.Carbohydrates!,
                Fats = (int)model.Fats!
            };

            await context.Recipes.AddAsync(recipe);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Recipe");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            List<Goal> goals = Enum.GetValues(typeof(Goal))
                .Cast<Goal>()
                .ToList();

            var recipe = context.Recipes.FirstOrDefault(r => r.Id == id);

            var recipeModel = new RecipeEditViewModel
            {
                Id = id,
                RecipeName = recipe.Name,
                Goals = goals,
                Preparation = recipe.Preparation,
                Ingredients = recipe.Ingredients,
                ImageUrl = recipe.ImageUrl,
                Goal = recipe.Goal.ToString(),
                Calories = (int)recipe.Calories!,
                Protein = (int)recipe.Protein!,
                Carbohydrates = (int)recipe.Carbohydrates!,
                Fats = (int)recipe.Fats!
            };
            return View(recipeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RecipeEditViewModel model)
        {

            List<Goal> goals = Enum.GetValues(typeof(Goal))
                .Cast<Goal>()
                .ToList();

            model.Goals = goals;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Recipe? recipe = await context.Recipes.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (recipe == null)
            {
                return NotFound();
            }
            if (!Goal.TryParse(model.Goal, out Goal goal))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            recipe.Name = model.RecipeName;
            recipe.Preparation = model.Preparation;
            recipe.Ingredients = model.Ingredients;
            recipe.ImageUrl = model.ImageUrl;
            recipe.Goal = goal;
            recipe.Calories = (int)model.Calories!;
            recipe.Protein = (int)model.Protein!;
            recipe.Carbohydrates = (int)model.Carbohydrates!;
            recipe.Fats = (int)model.Fats!;

            context.Recipes.Update(recipe);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Recipe");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var recipe = await context.Recipes
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (recipe == null)
            {
                return NotFound();
            }

            var viewModel = new RecipeDetailsViewModel
			{
                RecipeId = recipe.Id,
                Name = recipe.Name,
                Calories = recipe.Calories,
                Protein = recipe.Protein,
                Carbohydrates = recipe.Carbohydrates,
                Fats = recipe.Fats,
                ImageUrl = recipe.ImageUrl,
                Ingredients = recipe.Ingredients,
                Preparation = recipe.Preparation,
                UserId = recipe.UserID!
            };

            return View(viewModel);
        }

        //     [HttpGet]
        //     public async Task<IActionResult> Delete(Guid id)
        //     {
        //Console.WriteLine("Delete method invoked for id: " + id);
        //var recipe = await context.Recipes.FirstOrDefaultAsync(x => x.Id == id);

        //if (recipe == null)
        //{
        //	return NotFound("Recipe not found");
        //}

        //var model = new DeleteRecipeView();
        //         {
        //             model.Id = id;
        //             model.Name = recipe.Name;
        //             model.ImageUrl = recipe.ImageUrl;
        //         }
        //         return View(model);
        //     }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            //Console.WriteLine("=== Request Details ===");
            //Console.WriteLine($"Delete method invoked for id: {id}");
            //Console.WriteLine($"Request method: {Request.Method}");
            //Console.WriteLine($"Request path: {Request.Path}");
            //Console.WriteLine($"Request QueryString: {Request.QueryString}");
            //Console.WriteLine($"Referrer: {Request.Headers["Referer"]}");

            // Log all headers
            //Console.WriteLine("=== Headers ===");
            foreach (var header in Request.Headers)
            {
                Console.WriteLine($"{header.Key}: {header.Value}");
            }

            //if (id == Guid.Empty)
            //{
            //    Console.WriteLine("Empty GUID detected, redirecting to Index");
            //    return RedirectToAction(nameof(Index));
            //}

            var recipe = await context.Recipes.FirstOrDefaultAsync(x => x.Id == id);
            if (recipe == null)
            {
                //Console.WriteLine($"Recipe not found for id: {id}");
                //return NotFound("Recipe not found");
            }

            var model = new DeleteRecipeView
            {
                Id = id,
                Name = recipe.Name,
                ImageUrl = recipe.ImageUrl
            };

            //Console.WriteLine($"Model created with Id: {model.Id}, Name: {model.Name}");
            //Console.WriteLine("About to return view");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRecipeView model)
        {
            var recipe = await context.Recipes.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (recipe == null)
            {
                return NotFound();
            }

            recipe.IsDeleted = true;

            context.Recipes.Update(recipe);
            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Recipe");
        }
    }
}
