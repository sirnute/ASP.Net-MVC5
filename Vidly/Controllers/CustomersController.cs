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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(C => C.MembershipType).ToList();

            var ViewModel = new CustomerViewModel
            {
                Customers = customers
            };
            return View(ViewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(C => C.MembershipType).ToList().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }



        /*private List<Customer> getCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1 , Name = "Customer1"},
                new Customer { Id = 2,  Name = "Customer2" }
            };
        }
        */

    }
}