﻿using ASPCoreApplication2023.Models;

namespace ASPCoreApplication2023.Services.ServiceContracts
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieById(int id);
        Task CreateMovie(Movie movie);
        Task Edit(Movie movie);
        Task Delete(int id);
        Task<List<Movie>> GetMoviesByGenre(int genreId);
        Task<List<Movie>> GetAllMoviesOrderedAscending();
        Task<List<Movie>> GetMoviesByUserDefinedGenre(string userDefinedGenre);
    }
}
