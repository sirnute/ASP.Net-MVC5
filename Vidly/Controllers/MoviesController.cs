using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(M => M.GenreType).ToList();



            var ViewModel = new RandomMovieViewModel
            {
                Movies = movies
            };

            return View(ViewModel);
        }




        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(M => M.GenreType).ToList().SingleOrDefault(m => m.ID == id);

            if(movie == null)
                return HttpNotFound();

            return View(movie);
        }




        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };



            var ViewModel = new RandomMovieViewModel
            {
                Movie = movie
            };

            return View(ViewModel);
        }


        [Route("movies/releasad/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return View();
        }


        /*private List<Movie> getMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Shrek"},
                new Movie { Name = "Wall-e" }
            };
        }
        */
    }


}