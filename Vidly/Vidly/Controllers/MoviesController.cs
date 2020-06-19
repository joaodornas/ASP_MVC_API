using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

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

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var customerInDb = _context.Movies.Single(c => c.Id == movie.Id);

                customerInDb.Name = movie.Name;
                customerInDb.Genre = movie.Genre;
                customerInDb.dateAdded = movie.dateAdded;
                customerInDb.dateReleased = movie.dateReleased;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {

            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new Movie
            {
                Name = movie.Name,
                Genre = movie.Genre,
                dateAdded = movie.dateAdded,
                dateReleased = movie.dateReleased,
                inStock = movie.inStock
            };

            return View("MovieForm", viewModel);

        }

        // GET: Movies/Home
        public ActionResult Index()
        {

            var movies = _context.Movies.ToList();

            RandomMovieViewModel randModel = new RandomMovieViewModel();

            randModel.Movies = new List<Movie>();

            randModel.Movies = movies;

            return View(randModel);

        }

        // GET: Customer Details
        [Route("Movie/Details/{id?}")]
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            RandomMovieViewModel randModel = new RandomMovieViewModel();

            randModel.Movies = new List<Movie>();

            randModel.Movies.Add(movie);

            return View(randModel);
        }

    }
}