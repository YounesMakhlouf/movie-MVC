using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Repositories;
using ASPCoreApplication2023.Services.ServiceContracts;
using static ASPCoreApplication2023.Services.Services.MovieService;

namespace ASPCoreApplication2023.Services.Services
{
        public class MovieService : IMovieService
        {
            private readonly MovieRepository _movieRepository;

            public MovieService(MovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public List<Movie> GetAllMovies()
            {
                return _movieRepository.GetAllMovies();
            }

            public Movie GetMovieById(int id)
            {
                return _movieRepository.GetMovieById(id);
            }

            public void CreateMovie(Movie movie)
            {
                _movieRepository.CreateMovie(movie);
            }

            public void Edit(Movie movie)
            {
                _movieRepository.EditMovie(movie);
            }

            public void Delete(int id)
            {
                _movieRepository.DeleteMovie(id);
            }

            public List<Movie> GetMoviesByGenre(int genreId)
            {
                return _movieRepository.GetMoviesByGenre(genreId);
            }

            public List<Movie> GetAllMoviesOrderedAscending()
            {
                return _movieRepository.GetAllMoviesOrderedAscending();
            }

            public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
            {
                return _movieRepository.GetMoviesByUserDefinedGenre(userDefinedGenre);
            }
        }
}
