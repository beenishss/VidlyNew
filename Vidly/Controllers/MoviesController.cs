using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
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
            var movies = _context.Movies.Include(m => m.GenreType).ToList();
            return View(movies);
        }
        public ActionResult Random()
        {

            var movie = new Movie() {Id=1, Name = "Sherk!" };
            var customer = GetCustomers();
            var viewmodel = new RandomMovieViewModel(); 
            viewmodel.customer = customer;
            viewmodel.movie = movie;
            return View(viewmodel);
        }
        public List<Customer> GetCustomers()
        {
            var customer = new List<Customer>
            { new Customer{Id=1,Name="Beenish"},
              new Customer{Id=2,Name="Mubeen"} };

              return customer;
        }
        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Include(m => m.GenreType).SingleOrDefault(c => c.Id == id);
            return View(movie);
        }
        public ActionResult Edit(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(i => i.Id == id);
            var viewModel = new MovieGenreViewModel()
            {
                movie = movieInDb,
                GenreType = _context.GenreType.ToList()
            };
            return View("SaveMovie",viewModel);
        }
        public ActionResult SaveMovie()
        {
            var GenreType = _context.GenreType.ToList();
            var viewModel = new MovieGenreViewModel()
            {
                GenreType = GenreType
            };
            return View(viewModel);
        }
        public ActionResult EditSave(Movie movie)
        {
            if(movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                if (movieInDb == null)
                    return HttpNotFound();
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        
    }
}