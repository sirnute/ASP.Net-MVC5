using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

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
            return View();
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

        public ActionResult New()
        {
            var genreTypes = _context.GenreTypes.ToList();

            var viewModel = new MovieFormViewModel
            {
                Title = "New Movie",
                GenreTypes = genreTypes
            };
           
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie)
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(Movie)
                {
                   
                    GenreTypes = _context.GenreTypes.ToList()
                };
                return View("MovieForm", viewModel);
            }

            if(Movie.ID == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.ID == Movie.ID);
                movieInDb.Name = Movie.Name;
                movieInDb.GenreTypeId = Movie.GenreTypeId;
                movieInDb.ReleasedDate = Movie.ReleasedDate;
                movieInDb.NumberInStock = Movie.NumberInStock;
            }
           
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (Movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(Movie)
            {
                Title = "Edit Movie",
                GenreTypes = _context.GenreTypes.ToList()
            };

            return View("MovieForm", viewModel);
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