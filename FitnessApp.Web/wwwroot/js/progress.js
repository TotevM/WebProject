function initializeProgressChart(progressEntries) {
    // Extract labels (dates) and data points (weights)
    const labels = progressEntries.map(entry => new Date(entry.Date).toLocaleDateString());
    const values = progressEntries.map(entry => entry.Value);

    // Initialize the Chart.js chart
    const ctx = document.getElementById('progressChart').getContext('2d');
    new Chart(ctx, {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Weight (kg)',
                data: values,
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderWidth: 2,
                fill: true
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top'
                },
                title: {
                    display: true,
                    text: 'User Weight Over Time'
                }
            },
            scales: {
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                },
                y: {
                    beginAtZero: false,
                    title: {
                        display: true,
                        text: 'Weight (kg)'
                    }
                }
            }
        }
    });
}