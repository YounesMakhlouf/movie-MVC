using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPCoreApplication2023.Data;
using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Services.ServiceContracts;
using ASPCoreApplication2023.Services.Services;

namespace ASPCoreApplication2023.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
             var movies = await _movieService.GetAllMovies();
              return movies != null ? 
                          View(movies) :
                          Problem("Entity set 'AppdbContext.Movies'  is null.");
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _movieService.GetMovieById(id.Value);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _movieService.CreateMovie(movie);
                return RedirectToAction("Index");
            }

            // Gestion des erreurs de validation
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _movieService.Edit(movie);

                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _movieService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult MoviesByGenre(int id)
        {
            var movies = _movieService.GetMoviesByGenre(id);
            return View("index", movies);
        }

        public IActionResult MoviesOrderedAscending()
        {
            var movies = _movieService.GetAllMoviesOrderedAscending();
            return View("index", movies);
        }

        public IActionResult MoviesByUserDefinedGenre(string name)
        {
            var movies = _movieService.GetMoviesByUserDefinedGenre(name);
            return View("index", movies);
        }
    }
}
