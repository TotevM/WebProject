using FitnessApp.Data.Models;
using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class RecipesApiController : ControllerBase
{
    private readonly IRecipeService recipeService;

    public RecipesApiController(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRecipes()
    {
        var viewModel = await recipeService.DisplayRecipesAsync();
        if (viewModel == null)
        {
            return NotFound("No recipes found.");
        }

        return Ok(viewModel);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipeDetails(string id)
    {
        if (!Guid.TryParse(id, out var recipeGuid))
        {
            return BadRequest("Invalid recipe ID.");
        }

        var recipe = await recipeService.GetRecipeAsync(recipeGuid);
        if (recipe == null)
        {
            return NotFound("Recipe not found.");
        }

        var viewModel = recipeService.RecipeDetailsView(recipe);

        return Ok(viewModel);
    }
}