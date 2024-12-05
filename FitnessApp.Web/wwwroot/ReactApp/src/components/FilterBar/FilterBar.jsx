import { Search } from 'lucide-react';

export default function FilterBar({ searchTerm, setSearchTerm }) {
    return (
        <div className="flex items-center mb-4">
            <Search className="w-4 h-4 text-gray-600 mr-2" />
            <input
                type="text"
                placeholder="Search exercises..."
                value={searchTerm}
                onChange={(e) => setSearchTerm(e.target.value)}
                className="w-full px-3 py-2 border rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
        </div>
    );
}
