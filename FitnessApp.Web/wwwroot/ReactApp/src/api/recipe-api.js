import axios from 'axios';

const API_BASE_URL = "https://localhost:7136/api/RecipesApi";

export const fetchRecipes = async () => {
    try {
        const response = await axios.get(`${API_BASE_URL}`);
        return response.data.map(recipe => ({
            recipeId: recipe.recipeId,
            name: recipe.name,
            imageUrl: recipe.imageUrl || '/images/NoPictureAvailable.png', // default image if none exists
        }));
    } catch (error) {
        console.error("Failed to fetch recipes", error);
        throw error;
    }
};

export const fetchRecipeDetails = async (id) => {
    try {
        const response = await axios.get(`${API_BASE_URL}/${id}`);
        return response.data; //Recipe object is JSON
    } catch (error) {
        console.error("Failed to fetch recipe details", error);
        throw error;
    }
};

