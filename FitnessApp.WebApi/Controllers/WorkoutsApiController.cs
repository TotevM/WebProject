﻿using FitnessApp.Services.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using FitnessApp.Data;
using FitnessApp.Data.Models;
using FitnessApp.ViewModels;
using FitnessApp.ViewModels.ApiDTOs;

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
            return BadRequest(ModelState);
        }

        var workout = await workoutService.CreateAndReturnWorkout(workoutDto);

        foreach (var exerciseId in workoutDto.SelectedExerciseIds)
        {
            if (!Guid.TryParse(exerciseId, out Guid exerciseGuid))
            {
                return NotFound($"Invalid exercise ID: {exerciseId}");
            }

            bool exists = await workoutService.ExerciseExist(exerciseGuid);
            if (!exists)
            {
                return NotFound($"Exercise with ID {exerciseGuid} does not exist.");
            }

            await workoutService.AddWorkoutsExercisesToWorkout(workout, exerciseGuid);
        }

        if (workoutDto.UserId != null)
        {
            await workoutService.AddUserWorkoutAsync(workout.Id, workoutDto.UserId);
        }

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