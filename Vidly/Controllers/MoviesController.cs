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
            var Movies = _context.Movies.Include(c => c.Genre).ToList();
            return View(Movies);
        }
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null) {
                return HttpNotFound();
            }
            return View(movie);
        }
        ////[Route("movies/li/")]
        //public ActionResult ListAll()
        //{
        //    //var moviesList = new List<Movie>
        //    //{
        //    //    new Movie{Name = "Star Wars",Id=0},
        //    //    new Movie{Name = "James Bond",Id=1},
        //    //    new Movie{Name = "Pirates of the Caraiben",Id=2},
        //    //    new Movie{Name= "Lord of the rings",Id=3}
        //    //};
        //    var movies = new ListAllMovieViewModel
        //    {
        //        Movies = moviesList
        //};
        //    return View(movies);
        //}
        //// GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer{ Name= "Grzegorz"},
        //        new Customer{ Name= "Klaudia"},
        //        new Customer{ Name= "Aneta"},
        //        new Customer{ Name= "Marek"}
        //    };
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers

        //    };
        //    //ViewData["Movie"] = movie;
        //    return View(viewModel);
        //   // return HttpNotFound();
        //}
        //public ActionResult Edit(int id)
        //{
        //    return Content("id :" + id);
        //}
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrEmpty(sortBy))
        //        sortBy = "Name";
        //    return Content(String.Format("Page index is {0}, and it is sort by {1}", pageIndex, sortBy));
        //}
        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int? year, int month)
        //{
        //    return Content(String.Format("year: {0}, month: {1}.",year,month));
        //}


    }
}