import React, { useState, useEffect } from 'react';

import RecipeGrid from './RecipeList/RecipeGrid';
import RecipeDetailsModal from './RecipeList/RecipeDetailsModal';
import FilterBar from './FilterBar';
import { fetchRecipes, fetchRecipeDetails } from '../../api/recipe-api';

export default function Recipe({ loggedUserId }) {
    const [recipes, setRecipes] = useState([]);
    const [filteredRecipes, setFilteredRecipes] = useState([]);
    const [searchTerm, setSearchTerm] = useState('');
    const [selectedRecipe, setSelectedRecipe] = useState(null);
    const [modalOpen, setModalOpen] = useState(false);

    useEffect(() => {
        const loadRecipes = async () => {
            try {
                const data = await fetchRecipes();
                setRecipes(data);
                setFilteredRecipes(data);
            } catch (error) {
                console.error("Failed to fetch recipes:", error);
            }
        };

        loadRecipes();
    }, []);

    useEffect(() => {
        const lowerCaseSearchTerm = searchTerm.toLowerCase();
        const filtered = recipes.filter(recipe =>
            recipe.name.toLowerCase().includes(lowerCaseSearchTerm)
        );
        setFilteredRecipes(filtered);
    }, [searchTerm, recipes]);

    const detailsClickHandler = async (recipeId) => {
        try {
            const recipe = await fetchRecipeDetails(recipeId);

            const isEditable = recipe.userId === loggedUserId;

            setSelectedRecipe({ ...recipe, isEditable });
            setModalOpen(true);
        } catch (error) {
            console.error("Failed to fetch recipe details:", error);
            setSelectedRecipe({ name: "Error Loading Recipe" });
            setModalOpen(true);
        }
    };

    return (
        <>
            <FilterBar searchTerm={searchTerm} setSearchTerm={setSearchTerm} />
            <RecipeGrid recipes={recipes} onDetailsClick={detailsClickHandler} />
            <RecipeDetailsModal
                recipe={selectedRecipe}
                isOpen={modalOpen}
                onClose={() => setModalOpen(false)}
            />
        </>

    );
}
