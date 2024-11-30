document.addEventListener('DOMContentLoaded', () => {
    const recipeGrid = document.querySelector('.recipe-grid');
    const searchInput = document.getElementById('recipeSearch');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');

    // Modal Elements
    const recipeModal = document.getElementById('recipeModal');
    const modalElements = {
        title: document.getElementById('recipeModalLabel'),
        image: document.getElementById('recipeImage'),
        calories: document.getElementById('recipeCalories'),
        protein: document.getElementById('recipeProtein'),
        carbs: document.getElementById('recipeCarbohydrates'),
        fats: document.getElementById('recipeFats'),
        ingredients: document.getElementById('recipeIngredients'),
        preparation: document.getElementById('recipePreparation'),
        footer: document.querySelector('.modal-footer'),
    };

    // Add to Diet Modal Elements
    const dietSelect = document.getElementById('dietSelect');
    const modalRecipeId = document.getElementById('modalRecipeId');

    const loggedUserId = document.getElementById('loggedUserId')?.value;

    // Utility function: Filter recipes
    const filterRecipes = () => {
        const searchTerm = searchInput.value.toLowerCase().trim();
        recipeGrid?.querySelectorAll('.recipe-item').forEach(recipe => {
            const name = recipe.querySelector('.card-title').textContent.toLowerCase();
            recipe.style.display = name.includes(searchTerm) ? '' : 'none';
        });
    };

    // Utility function: Fetch and populate diets dropdown
    const populateDietsDropdown = async () => {
        try {
            const response = await fetch('https://localhost:7136/api/DietsApi/GetDiets');
            if (!response.ok) throw new Error('Failed to load diets');
            const diets = await response.json();

            // Clear and populate dropdown
            dietSelect.innerHTML = `<option value="" disabled selected>Select a diet</option>`;
            diets.forEach(diet => {
                const option = document.createElement('option');
                option.value = diet.Value; // Use "Value" for the option value
                option.textContent = diet.Text; // Use "Text" for the display text
                dietSelect.appendChild(option);
            });
        } catch (error) {
            console.error('Error loading diets:', error);
            alert('Failed to load diets. Please try again later.');
        }
    };

    // Event: Filter recipes
    if (searchInput && clearFiltersBtn) {
        searchInput.addEventListener('input', filterRecipes);
        clearFiltersBtn.addEventListener('click', () => {
            searchInput.value = '';
            filterRecipes();
        });
    }

    // Event: Prepare recipe details for modal
    recipeModal.addEventListener('show.bs.modal', async (event) => {
        const button = event.relatedTarget;
        const recipeId = button.getAttribute('data-recipe-id');

        try {
            const response = await fetch(`https://localhost:7136/api/RecipesApi/${recipeId}`);
            if (!response.ok) throw new Error('Failed to fetch recipe details');
            const recipe = await response.json();

            // Populate modal
            modalElements.title.textContent = recipe.Name;
            modalElements.image.src = recipe.ImageUrl || '/images/NoPictureAvailable.png';
            modalElements.image.alt = recipe.Name;
            modalElements.calories.textContent = recipe.Calories || 'N/A';
            modalElements.protein.textContent = recipe.Protein || 'N/A';
            modalElements.carbs.textContent = recipe.Carbohydrates || 'N/A';
            modalElements.fats.textContent = recipe.Fats || 'N/A';
            modalElements.ingredients.textContent = recipe.Ingredients || 'No ingredients listed.';
            modalElements.preparation.textContent = recipe.Preparation || 'No preparation instructions available.';

            // Add footer buttons if applicable
            modalElements.footer.innerHTML = loggedUserId === recipe.UserId
                ? `<a href="/Recipe/Edit/${recipe.RecipeId}" class="btn btn-primary me-2">Edit</a>
                   <a href="/Recipe/Delete/${recipe.RecipeId}" class="btn btn-danger">Delete</a>`
                : '';
        } catch (error) {
            console.error('Error fetching recipe details:', error);
            modalElements.title.textContent = 'Error Loading Recipe';
            modalElements.image.src = '/images/error-image.png';
            modalElements.ingredients.textContent = 'Unable to load recipe details.';
            modalElements.footer.innerHTML = '';
        }
    });

    // Event: Prepare Add to Diet modal
    const addToDietModal = document.getElementById('addToDietModal');
    addToDietModal.addEventListener('show.bs.modal', async (event) => {
        const button = event.relatedTarget;
        const recipeId = button.getAttribute('data-recipe-id');
        modalRecipeId.value = recipeId; // Populate hidden field with recipe ID

        await populateDietsDropdown(); // Ensure dropdown is populated
    });
});

document.addEventListener('DOMContentLoaded', () => {
    // Select all dropdown toggle elements
    const dropdownTriggers = document.querySelectorAll('.dropdown-toggle');

    // Initialize a Bootstrap dropdown instance for each trigger
    dropdownTriggers.forEach(trigger => {
        const dropdownInstance = new bootstrap.Dropdown(trigger);

        // Optional: Add a click event to toggle the dropdown manually (if needed)
        trigger.addEventListener('click', () => {
            dropdownInstance.toggle();
        });
    });
});