document.addEventListener('DOMContentLoaded', function () {
    const recipeGrid = document.querySelector('.recipe-grid');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');
    const searchInput = document.getElementById('recipeSearch');

    function filterRecipes() {
        if (!recipeGrid) return;

        const searchTerm = searchInput.value.toLowerCase().trim();
        const recipeItems = recipeGrid.querySelectorAll('.recipe-item');

        recipeItems.forEach(recipe => {
            const name = recipe.querySelector('.card-title').textContent.toLowerCase();
            recipe.style.display = searchTerm === '' || name.includes(searchTerm) ? '' : 'none';
        });
    }

    if (clearFiltersBtn && searchInput) {
        clearFiltersBtn.addEventListener('click', () => {
            searchInput.value = '';
            filterRecipes();
        });

        searchInput.addEventListener('input', filterRecipes);
    }
});