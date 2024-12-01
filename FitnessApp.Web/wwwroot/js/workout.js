document.querySelectorAll('.form-check-input').forEach(checkbox => {
    checkbox.addEventListener('change', () => {
        checkbox.closest('.exercise-item').classList.toggle('selected', checkbox.checked);
    });
});