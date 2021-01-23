using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name =  "Mary Williams" }
            };

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Smith"},
                new Customer { Id = 2, Name =  "Mary Williams" }
            };

            var selectedCustomer = customers.Where(customer => customer.Id == id).FirstOrDefault();

            if (selectedCustomer == null)
                return HttpNotFound();

            return View(selectedCustomer);
        }
    }
}