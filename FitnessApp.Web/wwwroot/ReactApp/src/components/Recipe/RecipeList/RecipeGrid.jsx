import React from 'react';
import RecipeCard from './RecipeCard';

export default function RecipeGrid({
    recipes,
    onDetailsClick
}) {
    return (
        <div className="recipe-grid">
            {recipes.map((recipe) => (
                <RecipeCard key={recipe.recipeId} recipe={recipe} onDetailsClick={onDetailsClick} />
            ))}
        </div>
    );
}
