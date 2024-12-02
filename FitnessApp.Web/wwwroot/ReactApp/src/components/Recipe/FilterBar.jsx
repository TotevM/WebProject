import React from 'react';

export default function FilterBar({ searchTerm, setSearchTerm }) {
    const handleInputChange = (e) => {
        setSearchTerm(e.target.value);
    };

    const handleClearFilters = () => {
        setSearchTerm('');
    };

    return (
        <div className="filter-bar">
            <div className="search-container">
                <i className="fas fa-search search-icon"></i>
                <input
                    type="text"
                    className="search-input"
                    placeholder="Search recipe by name..."
                    value={searchTerm}
                    onChange={handleInputChange}
                />
            </div>
            <div className="filter-groups">
                <button className="clear-filters-btn" onClick={handleClearFilters}>
                    Clear Filters
                </button>
            </div>
        </div>
    );
}
