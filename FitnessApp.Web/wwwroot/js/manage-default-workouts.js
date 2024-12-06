﻿document.addEventListener('DOMContentLoaded', function () {
    const addToWorkoutModal = document.getElementById("addToWorkoutModal");
    const exerciseSelect = document.getElementById("exerciseSelect");
    const modalWorkoutId = document.getElementById("modalWorkoutId");
    const filterCheckboxes = document.querySelectorAll('.filter-checkbox');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');

    let allExercises = []; // Cache all exercises for filtering

    async function loadExercises(workoutId) {
        try {
            const response = await fetch(`https://localhost:7136/api/ExercisesApi/GetExercises`);
            if (!response.ok) throw new Error('Failed to fetch exercises');
            allExercises = await response.json(); // Cache the exercises
            updateDropdown(allExercises);
        } catch (error) {
            console.error('Error fetching exercises:', error);
            exerciseSelect.innerHTML = `<option value="" disabled>Error loading exercises</option>`;
        }
    }

    function updateDropdown(exercises) {
        exerciseSelect.innerHTML = exercises.length
            ? exercises.map(exercise => `
                <option value="${exercise.Id}" data-muscle="${exercise.MuscleGroup}" data-difficulty="${exercise.Difficulty}">
                    <strong>${exercise.Name}</strong> - ${exercise.MuscleGroup} (${exercise.Difficulty})
                </option>
            `).join('')
            : `<option value="" disabled>No exercises match your filters</option>`;
    }

    function filterExercises() {
        const selectedMuscles = Array.from(filterCheckboxes)
            .filter(cb => cb.checked && cb.dataset.filter === 'muscle')
            .map(cb => cb.value);

        const filtered = selectedMuscles.length
            ? allExercises.filter(exercise => selectedMuscles.includes(exercise.MuscleGroup))
            : allExercises;

        updateDropdown(filtered);
    }

    // Event listeners for filtering
    filterCheckboxes.forEach(cb => cb.addEventListener('change', filterExercises));
    clearFiltersBtn.addEventListener('click', () => {
        filterCheckboxes.forEach(cb => cb.checked = false);
        filterExercises();
    });

    // Modal event listener
    addToWorkoutModal.addEventListener("show.bs.modal", async (event) => {
        const button = event.relatedTarget;
        const workoutId = button.getAttribute("data-workout-id");
        modalWorkoutId.value = workoutId;

        // Show loading state
        exerciseSelect.innerHTML = `<option value="" disabled selected>Loading exercises...</option>`;
        await loadExercises(workoutId);
    });
});

document.addEventListener('DOMContentLoaded', () => {
    const modalElement = document.getElementById('addToWorkoutModal'); // Adjust ID if necessary

    if (modalElement) {
        modalElement.addEventListener('hide.bs.modal', () => {
            const dropdownTriggers = document.querySelectorAll('.dropdown-toggle');
            dropdownTriggers.forEach(trigger => {
                new bootstrap.Dropdown(trigger);
            });
        });
    }
});