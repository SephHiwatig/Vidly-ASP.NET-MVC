using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private VidlyContext _context;

        public CustomersController()
        {
            _context = new VidlyContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var customers = new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "John Smith"},
            //    new Customer { Id = 2, Name =  "Mary Williams" }
            //};

            var customers = _context.Customers
                .Include(x => x.MembershipType)
                .ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            //var customers = new List<Customer>
            //{
            //    new Customer { Id = 1, Name = "John Smith"},
            //    new Customer { Id = 2, Name =  "Mary Williams" }
            //};

            //var selectedCustomer = customers.Where(customer => customer.Id == id).FirstOrDefault();

            var selectedCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (selectedCustomer == null)
                return HttpNotFound();

            return View(selectedCustomer);
        }
    }
}