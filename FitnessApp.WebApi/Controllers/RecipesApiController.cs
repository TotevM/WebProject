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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipeDetails(string id)
    {
        // Validate the Guid
        if (!Guid.TryParse(id, out var recipeGuid))
        {
            return BadRequest("Invalid recipe ID.");
        }

        // Retrieve the recipe
        var recipe = await recipeService.GetRecipeAsync(recipeGuid);
        if (recipe == null)
        {
            return NotFound("Recipe not found.");
        }

        // Create the view model
        var viewModel = recipeService.RecipeDetailsView(recipe);

        // Return as JSON
        return Ok(viewModel);
    }
}