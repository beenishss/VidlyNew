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
        public ActionResult NewForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes

            };
           return View(viewModel);
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
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
               
            }
            else
            {
                var custInDb = _context.Customers.Single(c => c.Id ==customer.Id);
                custInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
                custInDb.Name = customer.Name;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
                custInDb.Birthdate = customer.Birthdate;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            //as the form requires viewmodel so creating that
            var viewModel = new CustomerFormViewModel()
            {
                customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("NewForm", viewModel);
        }
    }
}