import React, { useState, useEffect } from 'react';
import { Plus, Trash2 } from 'lucide-react';
import FilterBar from '../FilterBar/FilterBar';

const DietForm = ({ userId }) => {
    const [dietName, setDietName] = useState('');
    const [dietImageUrl, setDietImageUrl] = useState(''); // State for the URL
    const [selectedRecipes, setSelectedRecipes] = useState([]);
    const [showRecipeList, setShowRecipeList] = useState(false);
    const [recipeSearchTerm, setRecipeSearchTerm] = useState('');
    const [recipeList, setRecipeList] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchRecipes = async () => {
            try {
                const response = await fetch('https://localhost:7136/api/RecipesApi/GetRecipes');
                if (!response.ok) throw new Error('Failed to fetch recipes');
                const data = await response.json();
                setRecipeList(data);
            } catch (error) {
                console.error(error);
                alert('Error loading recipes. Please try again.');
            } finally {
                setLoading(false);
            }
        };

        fetchRecipes();
    }, []);

    // Close modal when clicked outside or Escape is pressed
    const handleModalClose = () => setShowRecipeList(false);

    const handleClickOutside = (e) => {
        if (e.target === e.currentTarget) {
            handleModalClose();
        }
    };

    useEffect(() => {
        const handleEscKey = (e) => {
            if (e.key === 'Escape') handleModalClose();
        };

        document.addEventListener('keydown', handleEscKey);
        return () => document.removeEventListener('keydown', handleEscKey);
    }, []);

    const handleAddRecipe = (recipe) => {
        if (!selectedRecipes.some((r) => r.Id === recipe.Id)) {
            setSelectedRecipes([...selectedRecipes, recipe]);
            handleModalClose();
        }
    };

    const handleRemoveRecipe = (recipeId) => {
        setSelectedRecipes(selectedRecipes.filter((r) => r.Id !== recipeId));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const payload = {
            DietName: dietName,
            ImageUrl: dietImageUrl || null, // Include the URL in the payload
            SelectedRecipeIds: selectedRecipes.map((recipe) => recipe.Id.toString()),
            UserId: document.getElementById('loggedUserId')?.value || userId,
        };

        try {
            const response = await fetch('https://localhost:7136/api/DietsApi/CreateDiet', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            if (!response.ok) throw new Error('Failed to create diet');

            // Reset form fields
            setDietName('');
            setDietImageUrl('');
            setSelectedRecipes([]);
            window.history.back(); // Go back after successful submission
        } catch (error) {
            console.error(error);
            alert('Error creating diet. Please try again.');
        }
    };

    const availableRecipes = recipeList.filter(
        (recipe) =>
            !selectedRecipes.some((selected) => selected.Id === recipe.Id) &&
            (
                recipe.RecipeName.toLowerCase().includes(recipeSearchTerm.toLowerCase()) ||
                recipe.Goal.toLowerCase().includes(recipeSearchTerm.toLowerCase())
            )
    );

    return (
        <div className="max-w-2xl mx-auto p-6 bg-white shadow-lg rounded-lg">
            <h1 className="text-2xl font-bold mb-6 text-center">Create Diet Plan</h1>

            <form onSubmit={handleSubmit}>
                {/* Diet Name */}
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2" htmlFor="dietName">
                        Diet Plan Name
                    </label>
                    <input
                        type="text"
                        id="dietName"
                        value={dietName}
                        onChange={(e) => setDietName(e.target.value)}
                        className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                        placeholder="Enter diet plan name"
                        required
                    />
                </div>

                {/* Diet Image URL */}
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2" htmlFor="dietImageUrl">
                        Diet Plan Image URL
                    </label>
                    <input
                        type="url"
                        id="dietImageUrl"
                        value={dietImageUrl}
                        onChange={(e) => setDietImageUrl(e.target.value)}
                        className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-green-500"
                        placeholder="Enter an image URL for the diet (optional)"
                    />
                </div>

                {/* Recipe Selection */}
                <div className="mb-4">
                    <div className="flex justify-between items-center mb-2">
                        <h2 className="text-lg font-semibold">Recipes</h2>
                        <button
                            type="button"
                            onClick={() => setShowRecipeList(true)}
                            className="flex items-center bg-green-500 text-white px-3 py-1 rounded-lg hover:bg-green-600"
                        >
                            <Plus className="mr-2" />
                            Add Recipe
                        </button>
                    </div>

                    {selectedRecipes.length === 0 ? (
                        <p className="text-gray-500 italic">No recipes added yet</p>
                    ) : (
                        <div className="space-y-2">
                            {selectedRecipes.map((recipe) => (
                                <div
                                    key={recipe.Id}
                                    className="flex justify-between items-center bg-gray-100 p-3 rounded-lg"
                                >
                                    <div>
                                        <p className="font-medium">{recipe.RecipeName}</p>
                                        <p className="text-sm text-gray-600">
                                            {recipe.Calories} Cal | {recipe.Goal}
                                        </p>
                                    </div>
                                    <button
                                        type="button"
                                        onClick={() => handleRemoveRecipe(recipe.Id)}
                                        className="text-red-500 hover:text-red-700"
                                    >
                                        <Trash2 size={20} />
                                    </button>
                                </div>
                            ))}
                        </div>
                    )}
                </div>

                {/* Nutrition Summary */}

                <div className="bg-gray-100 p-3 rounded-lg mb-4">
                    <h3 className="font-semibold mb-2">Total Nutrition</h3>
                    <div className="flex justify-between">
                        <span>Total Calories:</span>
                        <span>{selectedRecipes.reduce((sum, recipe) => sum + recipe.Calories, 0)}</span>
                    </div>
                    <div className="flex justify-between">
                        <span>Total Protein:</span>
                        <span>{selectedRecipes.reduce((sum, recipe) => sum + recipe.Protein, 0)}g</span>
                    </div>
                    <div className="flex justify-between">
                        <span>Total Carbohydrates:</span>
                        <span>{selectedRecipes.reduce((sum, recipe) => sum + recipe.Carbohydrates, 0)}g</span>
                    </div>
                    <div className="flex justify-between">
                        <span>Total Fats:</span>
                        <span>{selectedRecipes.reduce((sum, recipe) => sum + recipe.Fats, 0)}g</span>
                    </div>
                </div>

                <button
                    type="submit"
                    disabled={selectedRecipes.length === 0}
                    className="w-full bg-green-500 text-white py-2 rounded-lg hover:bg-green-600 disabled:bg-gray-400"
                >
                    Create Diet Plan
                </button>
            </form>

            {showRecipeList && (
                <div
                    className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center"
                    onClick={handleClickOutside}
                >
                    <div className="bg-white p-6 rounded-lg w-96 max-h-96 overflow-y-auto">
                        <h2 className="text-xl font-bold mb-4 flex justify-between items-center">
                            <span>Select Recipes</span>

                            <button
                                onClick={handleModalClose}
                                className="text-gray-600 hover:text-gray-800"
                                aria-label="Close"
                            >
                                <span>×</span>
                            </button>
                        </h2>
                        <FilterBar searchTerm={recipeSearchTerm} setSearchTerm={setRecipeSearchTerm} />
                        {loading ? (
                            <p>Loading...</p>
                        ) : availableRecipes.length === 0 ? (
                            <p className="text-gray-500 italic">All recipes have been added</p>
                        ) : (
                            <div className="space-y-2">
                                {availableRecipes.map((recipe) => (
                                    <div
                                        key={recipe.Id}
                                        className="flex justify-between items-center bg-gray-100 p-3 rounded-lg"
                                    >
                                        <div>
                                            <p className="font-medium">{recipe.RecipeName}</p>
                                            <p className="text-sm text-gray-600">
                                                {recipe.Calories} Cal | {recipe.Goal}
                                            </p>
                                        </div>
                                        <button
                                            type="button"
                                            onClick={() => handleAddRecipe(recipe)}
                                            className="bg-green-500 text-white px-3 py-1 rounded-lg hover:bg-green-600"
                                        >
                                            Add
                                        </button>
                                    </div>
                                ))}
                            </div>
                        )}
                    </div>
                </div>
            )}
        </div>
    );
};

export default DietForm;
