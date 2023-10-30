export interface Movie {
    imdbID: string;
    title: string;
    year: string;
    type: string;
    poster: string;
  }
  
  export interface MovieDetail extends Movie {
    released: string;
  }