import React from 'react';

export default function RecipeDetailsModal({
    recipe,
    isOpen,
    onClose
}) {
    const modalClickPropagationHandler = (e) => {
        e.stopPropagation();
    }

    if (!isOpen) {
        return null;
    }

    return (
        <div className="modal show" onClick={onClose}>
            <div className="modal-dialog" onClick={modalClickPropagationHandler}>
                <div className="modal-content">
                    <div className="modal-header">
                        <h5 className="modal-title">{recipe?.name || "Error Loading Recipe"}</h5>
                        <button className="btn-close" onClick={onClose}></button>
                    </div>
                    <div className="modal-body">
                        <img
                            src={recipe?.imageUrl || '/images/NoPictureAvailable.png'}
                            alt={recipe?.name}
                        />
                        <p><strong>Calories:</strong> {recipe?.calories || "N/A"}</p>
                        <p><strong>Protein:</strong> {recipe?.protein || "N/A"}</p>
                        <p><strong>Carbohydrates:</strong> {recipe?.carbohydrates || "N/A"}</p>
                        <p><strong>Fats:</strong> {recipe?.fats || "N/A"}</p>
                        <h4>Ingredients</h4>
                        <p>{recipe?.ingredients || "No ingredients listed."}</p>
                        <h4>Preparation</h4>
                        <p>{recipe?.preparation || "No preparation steps available."}</p>
                    </div>
                    <div className="modal-footer">
                        {recipe?.isEditable && (
                            <>
                                <button className="btn btn-primary">Edit</button>
                                <button className="btn btn-danger">Delete</button>
                            </>
                        )}
                        <button className="btn btn-secondary" onClick={onClose}>
                            Close
                        </button>
                    </div>
                </div>
            </div>
        </div>
    );
}
