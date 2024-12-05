import React from 'react';
import WorkoutForm from './components/WorkoutForm/WorkoutForm';
import DietForm from './components/DietForm/DietForm';

function App() {
	const userId = document.getElementById('loggedUserId')?.value;
	const dietFormContainer = document.getElementById('dietFormContainer');
	const workoutFormContainer = document.getElementById('workoutFormContainer');

	return (
		<div className="workout-form">
			{dietFormContainer && <DietForm userId={userId}/>}
			{workoutFormContainer && <WorkoutForm userId={userId}/>}
		</div>
	);
}

export default App;
