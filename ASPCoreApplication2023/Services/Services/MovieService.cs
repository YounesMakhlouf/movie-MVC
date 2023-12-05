using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Repositories;
using ASPCoreApplication2023.Repositories.Interfaces;
using ASPCoreApplication2023.Services.ServiceContracts;
using static ASPCoreApplication2023.Services.Services.MovieService;

namespace ASPCoreApplication2023.Services.Services
{
        public class MovieService : IMovieService
        {
            private readonly IMovieRepository _movieRepository;

            public MovieService(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public Task<List<Movie>> GetAllMovies()
            {
                return _movieRepository.GetAllMovies();
            }

            public Task<Movie> GetMovieById(int id)
            {
                return _movieRepository.GetMovieById(id);
            }

            public Task CreateMovie(Movie movie)
            {
                return _movieRepository.CreateMovie(movie);
            }

            public Task Edit(Movie movie)
            {
                return _movieRepository.EditMovie(movie);
            }

            public Task Delete(int id)
            {
                return _movieRepository.DeleteMovie(id);
            }

            public Task<List<Movie>> GetMoviesByGenre(int genreId)
            {
                return _movieRepository.GetMoviesByGenre(genreId);
            }

            public Task<List<Movie>> GetAllMoviesOrderedAscending()
            {
                return _movieRepository.GetAllMoviesOrderedAscending();
            }

            public Task<List<Movie>> GetMoviesByUserDefinedGenre(string userDefinedGenre)
            {
                return _movieRepository.GetMoviesByUserDefinedGenre(userDefinedGenre);
            }
        }
}
