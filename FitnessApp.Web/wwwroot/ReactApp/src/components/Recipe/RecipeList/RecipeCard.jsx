import React from 'react';

export default function RecipeCard({
    recipe,
    onDetailsClick
}) {
    return (
        <div className="recipe-card">
            <div className="card-img-container">
                <img src={recipe.imageUrl || '/images/NoPictureAvailable.png'} alt={recipe.name} />
            </div>
            <div className="card-body">
                <h5 className="card-title">{recipe.name}</h5>
                <div className="card-buttons">
                    <button
                        className="card-btn details"
                        onClick={() => onDetailsClick(recipe.recipeId)}
                    >
                        View Details
                    </button>
                </div>
            </div>
        </div>
    );
};
