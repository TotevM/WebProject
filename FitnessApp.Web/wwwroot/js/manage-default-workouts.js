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

    const errorMessage = document.querySelector('.alert.alert-danger');

    const closeMessages = (message) => {
        if (message) {
            const closeButton = message.querySelector('.close-btn');
            closeButton.addEventListener('click', () => {
                message.classList.add('d-none');
            });
        }
    };

    closeMessages(errorMessage);

    // Auto-hide messages after 3 seconds
    if (errorMessage) {
        setTimeout(() => {
            if (errorMessage) errorMessage.classList.add('d-none');
        }, 3000);
    }

});

document.addEventListener('DOMContentLoaded', function () {
    function adjustCardHeights() {
        const rows = document.querySelectorAll('.row.row-cols-1.row-cols-md-2.row-cols-lg-3');
        rows.forEach(row => {
            let maxHeight = 0;
            const cards = row.querySelectorAll('.card:not(.d-flex)'); // Select all cards except the "Add" button

            // Calculate the maximum height of the cards
            cards.forEach(card => {
                maxHeight = Math.max(maxHeight, card.offsetHeight);
            });

            // Apply the maxHeight or a fallback height to the "Add" button container
            const addCard = row.querySelector('.card.d-flex');
            if (addCard) {
                addCard.style.height = maxHeight > 0 ? `${maxHeight}px` : '514px'; // Fallback height of 300px
            }
        });
    }

    // Call the function initially and whenever the window resizes
    adjustCardHeights();
    window.addEventListener('resize', adjustCardHeights);
});