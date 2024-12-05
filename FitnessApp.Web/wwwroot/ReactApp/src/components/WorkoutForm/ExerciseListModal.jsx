import React, { useEffect } from 'react';

import FilterBar from '../FilterBar/FilterBar';

const ExerciseListModal = ({ exercises, loading, onAddExercise, onClose, searchTerm, setSearchTerm }) => {

    // Close modal when clicked outside
    const handleClickOutside = (e) => {
        if (e.target === e.currentTarget) {
            onClose();  // Close if the background overlay is clicked
        }
    };

    useEffect(() => {
        // Adding event listener to handle escape key press for closing modal
        const handleEscKey = (e) => {
            if (e.key === 'Escape') onClose(); // Close modal on Escape key
        };

        document.addEventListener('keydown', handleEscKey);
        return () => document.removeEventListener('keydown', handleEscKey);
    }, [onClose]);

    return (
        <div
            className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center"
            onClick={handleClickOutside} // Close modal when clicking on the overlay
        >
            <div className="bg-white p-6 rounded-lg w-96 max-h-96 overflow-y-auto relative">
                <h2 className="text-xl font-bold mb-4 flex justify-between items-center">
                    <span>Select Exercises</span>
                    <button
                        onClick={onClose}
                        className="text-gray-600 hover:text-gray-800"
                        aria-label="Close"
                    >
                        <span>×</span> {/* Cross mark */}
                    </button>
                </h2>

                <FilterBar
                    searchTerm={searchTerm}
                    setSearchTerm={setSearchTerm}
                />

                {loading ? (
                    <p>Loading...</p>
                ) : exercises.length === 0 ? (
                    <p className="text-gray-500 italic">All exercises have been added</p>
                ) : (
                    <div className="space-y-2">
                        {exercises.map((exercise) => (
                            <div key={exercise.Id} className="flex justify-between items-center bg-gray-100 p-3 rounded-lg">
                                <div>
                                    <p className="font-medium">{exercise.Name}</p>
                                    <p className="text-sm text-gray-600">
                                        {exercise.MuscleGroup} - {exercise.Difficulty}
                                    </p>
                                </div>
                                <button
                                    type="button"
                                    onClick={() => onAddExercise(exercise)}
                                    className="bg-blue-500 text-white px-3 py-1 rounded-lg hover:bg-blue-600"
                                >
                                    Add
                                </button>
                            </div>
                        ))}
                    </div>
                )}
            </div>
        </div>
    );
};

export default ExerciseListModal;
