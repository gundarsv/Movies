import React, { useEffect, useState } from 'react';
import { Movie } from '../types/types';
import MovieList from './MovieList';
import { fetchRecentSearches, searchMoviesByTitle } from '../services/movieService';
import RecentSearches from './RecentSearches';

const MovieSearch: React.FC = () => {
    const [title, setTitle] = useState<string>('');
    const [movies, setMovies] = useState<Movie[]>([]);
    const [recentSearches, setRecentSearches] = useState<string[]>([]);

    const handleSearch = () => {
        searchMoviesByTitle(title).then(data => setMovies(data));
        fetchRecentSearches().then(data => setRecentSearches(data));
    };

    useEffect(() => {
        fetchRecentSearches().then(data => setRecentSearches(data));
    }, [])

    return (
        <div className="p-4">
            <input
                type="text"
                value={title}
                onChange={e => setTitle(e.target.value)}
                placeholder="Search for a movie..."
                className="p-2 border rounded" />
            <button onClick={handleSearch} className="p-2 ml-2 bg-blue-500 text-white rounded">
                Search
            </button>

            {movies && (
                <MovieList movies={movies} />
            )}

            {recentSearches && (
                <RecentSearches searches={recentSearches} />
            )}
        </div>
    );
};

export default MovieSearch;