document.addEventListener('DOMContentLoaded', () => {
    const userTable = document.querySelector('table'); // Target the user table
    const searchInput = document.getElementById('userSearch'); // Search input field
    const clearFiltersBtn = document.querySelector('.clear-filters-btn'); // Clear filters button
    const adminFilterBtn = document.querySelector('.admin-filter-btn'); // Admin filter button

    let showAdminsOnly = false; // Toggle state for admin filter

    // Utility function: Filter users
    const filterUsers = () => {
        const searchTerm = searchInput.value.toLowerCase().trim(); // Get search term
        userTable.querySelectorAll('tbody tr').forEach(row => { // Iterate through each row in the table body
            const username = row.cells[0].textContent.toLowerCase(); // Username column
            const isAdmin = row.cells[3].textContent.trim().toLowerCase() === 'yes'; // Admin status column

            // Filter by username and admin status toggle
            const matchesSearch = username.includes(searchTerm);
            const matchesAdminFilter = !showAdminsOnly || isAdmin;

            // Display row if both filters match
            row.style.display = (matchesSearch && matchesAdminFilter) ? '' : 'none';
        });
    };

    // Event: Search input
    if (searchInput) {
        searchInput.addEventListener('input', filterUsers); // Apply filter on search input change
    }

    // Event: Admin filter button
    if (adminFilterBtn) {
        adminFilterBtn.addEventListener('click', () => {
            showAdminsOnly = !showAdminsOnly; // Toggle admin filter state
            adminFilterBtn.textContent = showAdminsOnly ? 'Show All Users' : 'Show Admins Only'; // Update button text
            filterUsers(); // Apply filter
        });
    }

    // Event: Clear filters
    if (clearFiltersBtn) {
        clearFiltersBtn.addEventListener('click', () => {
            searchInput.value = ''; // Clear the input field
            showAdminsOnly = false; // Reset admin filter
            adminFilterBtn.textContent = 'Show Admins Only'; // Reset button text
            filterUsers(); // Reset the filter
        });
    }

    // Initial filtering on page load (optional)
    filterUsers();

    //Closing action message
    // Get the message elements
    const successMessage = document.querySelector('.alert.alert-success');
    const errorMessage = document.querySelector('.alert.alert-danger');

    // Add event listener to the 'X' button
    if (successMessage) {
        const closeButton = successMessage.querySelector('.close-btn');
        closeButton.addEventListener('click', () => {
            successMessage.classList.add('d-none');
        });
    }

    if (errorMessage) {
        const closeButton = errorMessage.querySelector('.close-btn');
        closeButton.addEventListener('click', () => {
            errorMessage.classList.add('d-none');
        });
    }

    // Automatically hide the message after 3 seconds if the user doesn't close it
    if (successMessage || errorMessage) {
        setTimeout(() => {
            if (successMessage) {
                successMessage.classList.add('d-none');
            }
            if (errorMessage) {
                errorMessage.classList.add('d-none');
            }
        }, 3000);
    }
});