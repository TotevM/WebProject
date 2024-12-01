using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class ExercisesApiController : ControllerBase
{
    private readonly IWorkoutService workoutService;

    public ExercisesApiController(IWorkoutService workoutService)
    {
        this.workoutService = workoutService;
    }

    [HttpGet("GetExercises")]
    public async Task<IActionResult> GetExercises()
    {
        var diets = await workoutService.GetAllExercisesModelAsync();

        return Ok(diets);
    }
}