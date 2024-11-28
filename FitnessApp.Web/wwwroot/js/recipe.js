document.addEventListener('DOMContentLoaded', function () {
    const recipeGrid = document.querySelector('.recipe-grid');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');
    const searchInput = document.getElementById('recipeSearch');
    const detailsButtons = document.querySelectorAll('.card-btn.details');
    // Get modal elements
    const recipeModal = document.getElementById('recipeModal');
    const modalTitle = document.getElementById('recipeModalLabel');
    const modalImage = document.getElementById('recipeImage');
    const modalCalories = document.getElementById('recipeCalories');
    const modalProtein = document.getElementById('recipeProtein');
    const modalCarbohydrates = document.getElementById('recipeCarbohydrates');
    const modalFats = document.getElementById('recipeFats');
    const modalIngredients = document.getElementById('recipeIngredients');
    const modalPreparation = document.getElementById('recipePreparation');
    const modalFooter = document.querySelector('.modal-footer');

    const loggedUserId = document.getElementById('loggedUserId')?.value; // Get logged-in user ID from hidden input

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

    detailsButtons.forEach(button => {
        button.addEventListener('click', async function () {
            const recipeId = this.getAttribute('data-recipe-id');
            try {
                const response = await fetch(`https://localhost:7136/api/RecipesApi/${recipeId}`);
                if (!response.ok) {
                    throw new Error('Failed to fetch recipe details');
                }

                const recipe = await response.json();

                // Populate modal with recipe details
                modalTitle.textContent = recipe.Name;
                modalImage.src = recipe.ImageUrl || '/images/NoPictureAvailable.png';
                modalImage.alt = recipe.Name;

                modalCalories.textContent = recipe.Calories || 'N/A';
                modalProtein.textContent = recipe.Protein || 'N/A';
                modalCarbohydrates.textContent = recipe.Carbohydrates || 'N/A';
                modalFats.textContent = recipe.Fats || 'N/A';

                modalIngredients.textContent = recipe.Ingredients || 'No ingredients listed.';
                modalPreparation.textContent = recipe.Preparation || 'No preparation instructions available.';

                // Clear and dynamically add footer buttons
                modalFooter.innerHTML = '';

                if (loggedUserId === recipe.UserId) {
                    const editButton = document.createElement('a');
                    editButton.href = `/Recipe/Edit/${recipe.RecipeId}`;
                    editButton.className = 'btn btn-primary me-2';
                    editButton.textContent = 'Edit';

                    const deleteButton = document.createElement('a');
                    deleteButton.href = `/Recipe/Delete/${recipe.RecipeId}`;
                    deleteButton.className = 'btn btn-danger me-2';
                    deleteButton.textContent = 'Delete';

                    modalFooter.appendChild(editButton);
                    modalFooter.appendChild(deleteButton);
                }

                recipeModal.classList.add('show');
            } catch (error) {
                console.error('Error fetching recipe details:', error);
                modalTitle.textContent = 'Error Loading Recipe';
                modalImage.src = '/images/error-image.png';
                modalIngredients.textContent = 'Unable to load recipe details. Please try again later.';
                modalFooter.innerHTML = ''; // Clear footer buttons in case of error
                recipeModal.classList.add('show');
            }
        });
    });

    window.addEventListener('click', (event) => {
        if (event.target === recipeModal) {
            recipeModal.classList.remove('show');
        }
    });
});