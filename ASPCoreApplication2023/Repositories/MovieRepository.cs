using ASPCoreApplication2023.Data;
using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppdbContext _db;

        public MovieRepository(AppdbContext db)
        {
            _db = db;
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            return await _db.Movies.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _db.Movies.FindAsync(id);
        }

        public async Task CreateMovie(Movie movie)
        {
            HandleImageUpload(movie);
            await _db.Movies.AddAsync(movie);
            await _db.SaveChangesAsync();
        }

        public async Task EditMovie(Movie movie)
        {
            HandleImageUpload(movie);
            _db.Update(movie);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = await GetMovieById(id);

            if (movie != null)
            {
                _db.Movies.Remove(movie);

                // Delete the image file from the /images folder
                if (!string.IsNullOrEmpty(movie.Photo))
                {
                    var imagePath = Path.Combine("wwwroot", movie.Photo.TrimStart('/'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }
                await _db.SaveChangesAsync();
            }
        }

        public async Task<List<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _db.Movies
                .Where(m => m.Genre.Id == genreId)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetAllMoviesOrderedAscending()
        {
            return await _db.Movies
                .OrderBy(m => m.Name)
                .ToListAsync();
        }

        public async Task<List<Movie>> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return await _db.Movies
                .Where(m => m.Genre.GenreName == userDefinedGenre)
                .ToListAsync();
        }

        private static void HandleImageUpload(Movie movie)
            {
                if (movie.ImageFile != null && movie.ImageFile.Length > 0)
                {
                    var imagePath = Path.Combine("wwwroot/images", movie.ImageFile.FileName);
                    using (var stream = new FileStream(imagePath, FileMode.Create))
                    {
                        movie.ImageFile.CopyTo(stream);
                    }

                    movie.Photo = $"/images/{movie.ImageFile.FileName}";
                }
            }
        }
}
