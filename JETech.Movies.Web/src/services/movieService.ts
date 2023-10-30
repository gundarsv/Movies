import { Movie, MovieDetail } from "../types/types";

export const fetchMovieById = async (id: string): Promise<MovieDetail> => {
    const response = await fetch(`https://localhost:7206/api/movies/${id}`);
    const data = await response.json();
    return data;
};

export const searchMoviesByTitle = async (title: string): Promise<Movie[]> => {
    const response = await fetch(`https://localhost:7206/api/movies/search?title=${title}`);
    const data = await response.json();
    return data;
}

export const fetchRecentSearches = async (): Promise<string[]> => {
    const response = await fetch(`https://localhost:7206/api/movies/recent-searches`);
    const data = await response.json();
    return data;
}