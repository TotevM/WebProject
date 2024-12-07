using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.ApiDTOs;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

[ApiController]
[Route("api/[controller]")]
public class DietsApiController : ControllerBase
{
    private readonly IDietService dietService;

    public DietsApiController(IDietService dietService)
    {
        this.dietService = dietService;
    }

    [HttpGet("GetDiets")]
    public async Task<IActionResult> GetDiets()
    {
        var diets = await dietService.GetDietsSelectListAsync();

        return Ok(diets);
    }

    [HttpPost("CreateDiet")]
    public async Task<IActionResult> CreateDiet([FromBody] DietCreationViewModel dietDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var diet = await dietService.CreateAndReturnDiet(dietDto);

        foreach (var recipeId in dietDto.SelectedRecipeIds)
        {
            if (!Guid.TryParse(recipeId, out Guid recipeGuid))
            {
                return NotFound($"Invalid recipe ID: {recipeId}");
            }

            bool exists = await dietService.RecipeExists(recipeGuid);
            if (!exists)
            {
                return NotFound($"Recipe with ID {recipeGuid} does not exist.");
            }

            await dietService.AddDietsRecipesToDiet(diet, recipeGuid);
        }

        await dietService.UpdateDietMacronutrientsAsync(diet.Id);

        if (dietDto.UserId != null)
        {
            await dietService.AddUserDietAsync(diet.Id, dietDto.UserId);
        }

        return CreatedAtAction(
            nameof(CreateDiet),
            new { id = diet.Id },
            new DietDto()
            {
                Id = diet.Id.ToString(),
                Name = diet.Name,
                ImageUrl = diet.ImageUrl,
                RecipeIds = diet.DietsRecipes.Select(dr => dr.RecipeId.ToString()).ToList()
            });
    }
}