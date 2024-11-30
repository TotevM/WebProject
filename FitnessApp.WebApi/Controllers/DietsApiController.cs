using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
}