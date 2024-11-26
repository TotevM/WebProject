document.addEventListener('DOMContentLoaded', function () {
    const exerciseGrid = document.querySelector('.exercise-grid');
    const filterCheckboxes = document.querySelectorAll('.filter-checkbox');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');
    const searchInput = document.getElementById('exerciseSearch');

    function filterExercises() {
        // Ensure we have an exercise grid to work with
        if (!exerciseGrid) return;

        const selectedDifficulties = Array.from(document.querySelectorAll('.filter-checkbox[data-filter="difficulty"]:checked'))
            .map(cb => cb.value);
        const selectedMuscles = Array.from(document.querySelectorAll('.filter-checkbox[data-filter="muscle"]:checked'))
            .map(cb => cb.value);
        const searchTerm = searchInput.value.toLowerCase().trim();

        const exerciseItems = exerciseGrid.querySelectorAll('.exercise-item');
        exerciseItems.forEach(exercise => {
            // Check if these data attributes exist for both index and restore pages
            const difficulty = exercise.getAttribute('data-difficulty') ||
                exercise.querySelector('.tag.difficulty-').textContent.trim();
            const muscle = exercise.getAttribute('data-muscle') ||
                exercise.querySelector('.tag.muscle-').textContent.trim();
            const name = exercise.querySelector('.card-title').textContent.toLowerCase();

            const difficultyMatch = selectedDifficulties.length === 0 || selectedDifficulties.includes(difficulty);
            const muscleMatch = selectedMuscles.length === 0 || selectedMuscles.includes(muscle);
            const nameMatch = searchTerm === '' || name.includes(searchTerm);

            exercise.style.display = difficultyMatch && muscleMatch && nameMatch ? '' : 'none';
        });
    }

    // Event listeners
    if (filterCheckboxes && clearFiltersBtn && searchInput) {
        filterCheckboxes.forEach(checkbox => {
            checkbox.addEventListener('change', filterExercises);
        });

        clearFiltersBtn.addEventListener('click', () => {
            filterCheckboxes.forEach(checkbox => {
                checkbox.checked = false;
            });
            searchInput.value = '';
            filterExercises();
        });

        searchInput.addEventListener('input', filterExercises);
    }
});