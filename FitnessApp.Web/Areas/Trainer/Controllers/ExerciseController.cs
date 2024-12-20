﻿using FitnessApp.Common.Enumerations;
using FitnessApp.Services.ServiceContracts;
using FitnessApp.ViewModels;
using FitnessApp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FitnessApp.Common.ApplicationConstants;

namespace FitnessApp.Web.Areas.Trainer.Controllers
{
    [Authorize(Roles = TrainerRole)]
    [Area(TrainerRole)]
    public class ExerciseController : BaseController
    {
        private readonly IExerciseService exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ExerciseIndexView> exercises = await exerciseService.GetAllExercisesAsync(false);
            return View(exercises);
        }

        public async Task<IActionResult> Delete(string id)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var exercise = await exerciseService.GetExerciseAsync(exerciseGuid);

            if (exercise == null)
            {
                return NotFound();
            }

            await exerciseService.ChangeExerciseWorkoutsStateAsync(exerciseGuid, true);

            await exerciseService.SetExerciseActivityAsync(exercise, true);

            return RedirectToAction("Index", "Exercise");
        }

        [HttpGet]
        public async Task<IActionResult> Restore()
        {
            var exercises = await exerciseService.GetAllExercisesAsync(true);
            return View(exercises);
        }

        [HttpPost]
        public async Task<IActionResult> Restore(string id)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref exerciseGuid);

            if (!isGuidValid)
            {
                return NotFound();
            }

            var exercise = await exerciseService.GetExerciseAsync(exerciseGuid);

            if (exercise == null)
            {
                return NotFound();
            }

            await exerciseService.ChangeExerciseWorkoutsStateAsync(exerciseGuid, false);
            await exerciseService.SetExerciseActivityAsync(exercise, false);

            return RedirectToAction("Restore", "Exercise");
        }

        [HttpPost]
        public async Task<IActionResult> RestoreAll()
        {
            await exerciseService.RestoreAll();

            return RedirectToAction("Index", "Exercise");
        }

        [HttpGet]
        public IActionResult AddExercise()
        {
            AddExerciseViewModel model = exerciseService.AddExerciseViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise(AddExerciseViewModel model)
        {
            ;
            if (!ModelState.IsValid)
            {
                model = exerciseService.AddExerciseViewModel();
                return View(model);
            }

            if (!Enum.TryParse(model.Difficulty, out Difficulty difficulty))
            {
                throw new InvalidOperationException("Invalid data!");
            }
            if (!Enum.TryParse(model.MuscleGroup, out MuscleGroup muscleGroup))
            {
                throw new InvalidOperationException("Invalid data!");
            }
            await exerciseService.AddExercise(model, difficulty, muscleGroup);
            return RedirectToAction("Index", "Exercise");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(id, ref exerciseGuid);
            if (!isGuidValid)
            {
                return NotFound();
            }

            var exercise = await exerciseService.GetExerciseByIdAsync(exerciseGuid);

            if (exercise == null)
            {
                return NotFound();
            }

            AddExerciseViewModel model = exerciseService.MapToEditView(exercise);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AddExerciseViewModel model)
        {
            Guid exerciseGuid = Guid.Empty;
            bool isGuidValid = IsGuidValid(model.Id, ref exerciseGuid);
            if (!isGuidValid)
            {
                return NotFound();
            }

            var exercise = await exerciseService.GetExerciseByIdAsync(exerciseGuid);

            if (!Enum.TryParse(model.Difficulty, out Difficulty difficulty))
            {
                throw new InvalidOperationException("Invalid data!");
            }
            if (!Enum.TryParse(model.MuscleGroup, out MuscleGroup muscleGroup))
            {
                throw new InvalidOperationException("Invalid data!");
            }

            await exerciseService.EditExercise(exercise!, model, difficulty, muscleGroup);

            return RedirectToAction(nameof(Index));
        }
    }
}
