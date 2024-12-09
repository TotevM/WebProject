using Microsoft.AspNetCore.Mvc;

using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels.RecipeModels;

[ApiController]
[Route("api/[controller]")]
public class RecipesApiController : ControllerBase
{
    private readonly IRecipeService recipeService;

    public RecipesApiController(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    [HttpGet("GetRecipes")]
    [ProducesResponseType(typeof(List<RecipeViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRecipes()
    {
        var viewModel = await recipeService.GetAllRecipeModelAsync();
        if (viewModel == null)
        {
            return NotFound("No recipes found.");
        }

        return Ok(viewModel);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(RecipeDetailsViewModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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