import React, { useState, useEffect } from 'react';
import { Plus, } from 'lucide-react';

import ExerciseListModal from './ExerciseListModal';
import SelectedExerciseList from './SelectedExerciseList';

const WorkoutForm = ({ userId }) => {
    const [workoutName, setWorkoutName] = useState('');
    const [selectedExercises, setSelectedExercises] = useState([]);
    const [showExerciseList, setShowExerciseList] = useState(false);
    const [exerciseSearchTerm, setExerciseSearchTerm] = useState('');
    const [exerciseList, setExerciseList] = useState([]);
    const [loading, setLoading] = useState(true);

    // Fetch exercises from the API
    useEffect(() => {
        const fetchExercises = async () => {
            try {
                const response = await fetch('https://localhost:7136/api/ExercisesApi/GetExercises');
                if (!response.ok) throw new Error('Failed to fetch exercises');
                const data = await response.json();
                setExerciseList(data);
            } catch (error) {
                console.error(error);
                alert('Error loading exercises. Please try again.');
            } finally {
                setLoading(false);
            }
        };

        fetchExercises();
    }, []);

    const handleAddExercise = (exercise) => {
        if (!selectedExercises.some(e => e.Id === exercise.Id)) {
            setSelectedExercises([...selectedExercises, exercise]);
            setShowExerciseList(false);
        }
    };

    const handleRemoveExercise = (exerciseId) => {
        setSelectedExercises(selectedExercises.filter(e => e.Id !== exerciseId));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const payload = {
            WorkoutName: workoutName,
            SelectedExerciseIds: selectedExercises.map((exercise) => exercise.Id.toString()),
            UserId: document.getElementById("loggedUserId")?.value,
        };

        try {
            const response = await fetch('https://localhost:7136/api/WorkoutsApi/CreateWorkout', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(payload),
            });

            if (!response.ok) throw new Error('Failed to create workout');

            setWorkoutName('');
            setSelectedExercises([]);

            // Redirect to the previous page using history.back()
            window.history.back();
        } catch (error) {
            console.error(error);
            alert('Error creating workout. Please try again.');
        }
    };

    const availableExercises = exerciseList.filter((exercise) =>
        !exercise.IsDeleted &&
        !selectedExercises.some((selected) => selected.Id === exercise.Id) &&
        (exercise.Name.toLowerCase().includes(exerciseSearchTerm.toLowerCase()) ||
            exercise.MuscleGroup.toLowerCase().includes(exerciseSearchTerm.toLowerCase()))
    );

    return (
        <div className="max-w-2xl mx-auto p-6 bg-white shadow-lg rounded-lg">
            <h1 className="text-2xl font-bold mb-6 text-center">Create Workout</h1>

            <form onSubmit={handleSubmit}>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2" htmlFor="workoutName">
                        Workout Name
                    </label>
                    <input
                        type="text"
                        id="workoutName"
                        value={workoutName}
                        onChange={(e) => setWorkoutName(e.target.value)}
                        className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
                        placeholder="Enter workout name"
                        required
                    />
                </div>

                <div className="mb-4">
                    <div className="flex justify-between items-center mb-2">
                        <h2 className="text-lg font-semibold">Exercises</h2>
                        <button
                            type="button"
                            onClick={() => setShowExerciseList(true)}
                            className="flex items-center bg-blue-500 text-white px-3 py-1 rounded-lg hover:bg-blue-600"
                        >
                            <Plus className="w-4 h-4 mr-2" />
                            Add Exercise
                        </button>
                    </div>

                    <SelectedExerciseList
                        selectedExercises={selectedExercises}
                        onRemoveExercise={handleRemoveExercise}
                    />
                </div>

                <button
                    type="submit"
                    disabled={selectedExercises.length === 0}
                    className="w-full bg-green-500 text-white py-2 rounded-lg hover:bg-green-600 disabled:bg-gray-400"
                >
                    Create Workout
                </button>
            </form>

            {showExerciseList && (
                <ExerciseListModal
                    exercises={availableExercises}
                    loading={loading}
                    onAddExercise={handleAddExercise}
                    onClose={() => setShowExerciseList(false)}
                    searchTerm={exerciseSearchTerm}
                    setSearchTerm={setExerciseSearchTerm}
                />
            )}
        </div>
    );
};

export default WorkoutForm;
