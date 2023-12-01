using ASPCoreApplication2023.Data;
using ASPCoreApplication2023.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPCoreApplication2023.Repositories
{
    public class MovieRepository
    {
        private readonly AppdbContext _db;

        public MovieRepository(AppdbContext db)
        {
            _db = db;
        }

        public List<Movie> GetAllMovies()
        {
            return _db.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return _db.Movies.Find(id);
        }

        public void CreateMovie(Movie movie)
        {
            HandleImageUpload(movie);
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void EditMovie(Movie movie)
        {
            HandleImageUpload(movie);
            _db.Entry(movie).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var movie = GetMovieById(id);

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
                _db.SaveChanges();
            }
        }

        public List<Movie> GetMoviesByGenre(int genreId)
        {
            return _db.Movies
                .Where(m => m.Genre.Id == genreId)
                .ToList();
        }

        public List<Movie> GetAllMoviesOrderedAscending()
        {
            return _db.Movies
                .OrderBy(m => m.Name)
                .ToList();
        }

        public List<Movie> GetMoviesByUserDefinedGenre(string userDefinedGenre)
        {
            return _db.Movies
                .Where(m => m.Genre.GenreName == userDefinedGenre)
                .ToList();
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
