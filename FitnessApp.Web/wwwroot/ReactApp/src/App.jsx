import React from 'react';
import WorkoutForm from './components/WorkoutForm/WorkoutForm';

function App() {
	const userId = document.getElementById('loggedUserId')?.value;

	return (
		<div className="workout-form">
			<WorkoutForm userId={userId}/>
		</div>
	);
}

export default App;
