import React from 'react';
import { Trash2 } from 'lucide-react';

const SelectedExerciseList = ({ selectedExercises, onRemoveExercise }) => {
  return selectedExercises.length === 0 ? (
    <p className="text-gray-500 italic">No exercises added yet</p>
  ) : (
    <div className="space-y-2">
      {selectedExercises.map((exercise) => (
        <div key={exercise.Id} className="flex justify-between items-center bg-gray-100 p-3 rounded-lg">
          <div>
            <p className="font-medium">{exercise.Name}</p>
            <p className="text-sm text-gray-600">
              {exercise.MuscleGroup} - {exercise.Difficulty}
            </p>
          </div>
          <button
            type="button"
            onClick={() => onRemoveExercise(exercise.Id)}
            className="text-red-500 hover:text-red-700"
          >
            <Trash2 size={20} />
          </button>
        </div>
      ))}
    </div>
  );
};

export default SelectedExerciseList;
