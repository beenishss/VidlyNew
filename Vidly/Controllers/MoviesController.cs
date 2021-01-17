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
        // GET: Movies
        private ApplicationDbContext _context;
        
        public ActionResult Index()
        {
            return View();
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
        
    }
}