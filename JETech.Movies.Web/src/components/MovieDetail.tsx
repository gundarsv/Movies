import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { MovieDetail } from '../types/types';
import { fetchMovieById } from '../services/MovieService';

const MovieDetailComponent: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    const [movie, setMovie] = useState<MovieDetail | null>(null);

    useEffect(() => {
        fetchMovieById(id ?? '').then(data => setMovie(data));
    }, [id]);

    if (!movie) return <div>Loading...</div>;

    return (
        <div className="p-4">
            <h1 className="text-2xl font-bold mb-4">{movie.title}</h1>
            <img src={movie.poster} alt={movie.title} className="w-1/4 shadow-lg rounded" />
            <p className="mt-2"><strong>Year:</strong> {movie.year}</p>
            <p><strong>Type:</strong> {movie.type}</p>
            <p><strong>Released:</strong> {movie.released}</p>
        </div>
    );
};

export default MovieDetailComponent;