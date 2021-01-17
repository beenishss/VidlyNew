using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            // List<Customer> cust = GetCustomers();
            var cust = _context.Customers.Include(c=>c.MembershipType);
            return View(cust);
        }
        public ActionResult Details(int id)
        {

            //  var customer= GetCustomers().Where(i=>i.Id==id).FirstOrDefault();
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        
        public List<Customer> GetCustomers()
        {
            List<Customer> customer = new List<Customer>()
            {
                new Customer{Id=1,Name="Beenish"},
                new Customer{Id=2,Name="Momina"}
            };
            return customer;
        }
    }
}