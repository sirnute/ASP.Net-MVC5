using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    [Authorize(Roles = RoleName.canManageMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;//db context

        public MoviesController()//default contructor
        {
            _context = new ApplicationDbContext();//intialize dbcontext
        }

        // GET /api/movies
        public IEnumerable<MovieDto> GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies

                .Include(m => m.GenreType)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie)); ;
        }


        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.ID = movie.ID;

            //customerDto here is passed because it is the actual object that was created
            return Created(new Uri(Request.RequestUri + "/" + movie.ID), movieDto);
        }


        [HttpPut]
        //PUT /api/movies/1
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDb == null)
                return NotFound();


            //Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb); - long way
            Mapper.Map(movieDto, movieInDb);//short way

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        //PUT /api/movies/1
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.ID == id);

            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
