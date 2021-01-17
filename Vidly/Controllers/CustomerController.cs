using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> cust = GetCustomers();
            return View(cust);
        }
        public ActionResult Details(int id)
        {
          
           var customer= GetCustomers().Where(i=>i.Id==id).FirstOrDefault();
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