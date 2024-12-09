using Microsoft.AspNetCore.Mvc;

using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;

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
    [ProducesResponseType(typeof(List<ExerciseViewModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetExercises()
    {
        var diets = await workoutService.GetAllExercisesModelAsync();

        return Ok(diets);
    }
}