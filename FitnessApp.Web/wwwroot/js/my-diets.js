document.addEventListener('DOMContentLoaded', function () {
    const dietGrid = document.querySelector('.row');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');
    const searchInput = document.getElementById('dietSearch');
    const calorieRange = document.getElementById('calorieRange');
    const calorieValue = document.getElementById('calorieValue');

    function filterDiets() {
        if (!dietGrid) return;

        const searchTerm = searchInput.value.toLowerCase().trim();
        const maxCalories = parseInt(calorieRange.value);
        const dietItems = dietGrid.querySelectorAll('.diet-card');

        dietItems.forEach(diet => {
            const name = diet.querySelector('.card-title').textContent.toLowerCase();
            const calories = parseInt(diet.getAttribute('data-calories')) || 0;

            const matchesSearch = searchTerm === '' || name.includes(searchTerm);
            const matchesCalories = calories <= maxCalories;

            diet.style.display = (matchesSearch && matchesCalories) ? '' : 'none';
        });

        calorieValue.textContent = `Up to ${maxCalories}`;
    }


    // Event listeners
    if (clearFiltersBtn && searchInput && calorieRange) {
        clearFiltersBtn.addEventListener('click', () => {
            searchInput.value = '';
            calorieRange.value = calorieRange.max;
            calorieValue.textContent = `Up to ${calorieRange.max}`;
            filterDiets();
        });
        searchInput.addEventListener('input', filterDiets);
        calorieRange.addEventListener('input', filterDiets);
    }

    // Initial filter to set up the view
    filterDiets();
});