import React from 'react';
import { Movie } from '../types/types';
import { Link } from 'react-router-dom';

interface IMovieListProps {
    movies: Movie[];
}

const MovieList: React.FC<IMovieListProps> = ({ movies }) => {
    console.log(movies);

    return (
        <div className="mt-4">
          {movies.map(movie => (
            <div key={movie.imdbID} className="mb-2">
              <Link to={`/movie/${movie.imdbID}`} className="text-blue-500 hover:underline">
                {movie.title}
              </Link>
            </div>
          ))}
        </div>
    );
};

export default MovieList;