using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsApiController : ControllerBase
{
    private readonly FitnessDBContext context;
    private readonly IWorkoutService workoutService;

    public WorkoutsApiController(IWorkoutService workoutService, FitnessDBContext context)
    {
        this.workoutService = workoutService;
        this.context = context;
    }

    [HttpPost("CreateWorkout")]
    public async Task<IActionResult> CreateWorkout([FromBody] WorkoutCreationViewModel workoutDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // Return validation errors if model is invalid
        }

        var workout = new Workout
        {
            Id = Guid.NewGuid(),
            Name = workoutDto.WorkoutName,
            UserID = User.FindFirstValue(ClaimTypes.NameIdentifier)
        };

        foreach (var exerciseId in workoutDto.SelectedExerciseIds)
        {
            if (!Guid.TryParse(exerciseId, out Guid exerciseGuid))
            {
                return NotFound($"Invalid exercise ID: {exerciseId}");
            }

            //TODO: Check if exercise is deleted == false
            bool exists = await workoutService.ExerciseExist(exerciseGuid);
            if (!exists)
            {
                return NotFound($"Exercise with ID {exerciseGuid} does not exist.");
            }

            workout.WorkoutsExercises.Add(new WorkoutExercise
            {
                ExerciseId = exerciseGuid,
                WorkoutId = workout.Id
            });
        }

        context.Workouts.Add(workout);
        await context.SaveChangesAsync();
        
        return CreatedAtAction(
            nameof(CreateWorkout),
            new { id = workout.Id },
            new WorkoutDto
            {
                Id = workout.Id.ToString(),
                Name = workout.Name,
                ExerciseIds = workout.WorkoutsExercises.Select(we => we.ExerciseId.ToString()).ToList()
            });
    }

}

//Quick solution - to fix: return CreatedAtAction(... , value: without DTO)
public class WorkoutDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<string> ExerciseIds { get; set; } = new();
}