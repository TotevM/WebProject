document.addEventListener('DOMContentLoaded', () => {
    const userTable = document.querySelector('table');
    const searchInput = document.getElementById('userSearch');
    const clearFiltersBtn = document.querySelector('.clear-filters-btn');
    const userFilterBtn = document.querySelector('.user-filter-btn');
    const trainerFilterBtn = document.querySelector('.trainer-filter-btn');

    let showActiveUsersOnly = false;
    let showTrainersOnly = false;

    // Filter function
    const filterUsers = () => {
        const searchTerm = searchInput.value.toLowerCase().trim(); // Get the search term
        userTable.querySelectorAll('tbody tr').forEach(row => {
            const username = row.cells[0].textContent.toLowerCase(); // Get username
            const isActive = row.querySelector('.bg-success') !== null; // Check if the user is active (based on the class 'bg-success')
            const isTrainer = row.querySelector('.bg-warning') !== null; // Check if the user is a trainer (based on the class 'bg-warning')

            // Apply all filters: Search, Active/Inactive status, and Trainer status
            const matchesSearch = username.includes(searchTerm);
            const matchesActiveFilter = !showActiveUsersOnly || isActive;
            const matchesTrainerFilter = !showTrainersOnly || isTrainer;

            row.style.display = (matchesSearch && matchesActiveFilter && matchesTrainerFilter) ? '' : 'none';
        });
    };

    // Event: Search input
    if (searchInput) {
        searchInput.addEventListener('input', filterUsers);
    }

    // Event: Active users filter button
    if (userFilterBtn) {
        userFilterBtn.addEventListener('click', () => {
            showActiveUsersOnly = !showActiveUsersOnly;
            userFilterBtn.textContent = showActiveUsersOnly ? 'Show All Users' : 'Show Active Users';
            filterUsers();
        });
    }

    // Event: Trainers filter button
    if (trainerFilterBtn) {
        trainerFilterBtn.addEventListener('click', () => {
            showTrainersOnly = !showTrainersOnly;
            trainerFilterBtn.textContent = showTrainersOnly ? 'Show All Users' : 'Show Trainers';
            filterUsers();
        });
    }

    // Event: Show All Users button
    const showAllUsersBtn = document.querySelector('.show-all-users-btn');
    if (showAllUsersBtn) {
        showAllUsersBtn.addEventListener('click', () => {
            // Reset both filters
            showActiveUsersOnly = false;
            showTrainersOnly = false;

            // Reset button texts
            userFilterBtn.textContent = 'Show Active Users';
            trainerFilterBtn.textContent = 'Show Trainers';

            // Clear search input
            searchInput.value = '';

            // Apply the reset filter
            filterUsers();
        });
    }

    // Event: Clear filters button
    if (clearFiltersBtn) {
        clearFiltersBtn.addEventListener('click', () => {
            // Reset both filters
            showActiveUsersOnly = false;
            showTrainersOnly = false;

            // Reset button texts
            userFilterBtn.textContent = 'Show Active Users';
            trainerFilterBtn.textContent = 'Show Trainers';

            // Clear search input
            searchInput.value = '';

            // Apply the reset filter
            filterUsers();
        });
    }

    // Message closing logic
    const successMessage = document.querySelector('.alert.alert-success');
    const errorMessage = document.querySelector('.alert.alert-danger');

    const closeMessages = (message) => {
        if (message) {
            const closeButton = message.querySelector('.close-btn');
            closeButton.addEventListener('click', () => {
                message.classList.add('d-none');
            });
        }
    };

    closeMessages(successMessage);
    closeMessages(errorMessage);

    // Auto-hide messages after 3 seconds
    if (successMessage || errorMessage) {
        setTimeout(() => {
            if (successMessage) successMessage.classList.add('d-none');
            if (errorMessage) errorMessage.classList.add('d-none');
        }, 3000);
    }

    // Initial filtering
    filterUsers();
});
