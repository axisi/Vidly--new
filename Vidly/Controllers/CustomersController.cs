using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var Customers = GetCustomers();
           
            return View(Customers);
        }
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer> {
               new Customer { Name = "Grzegorz", Id = 0 },
               new Customer { Name = "Klaudia", Id = 1 },
               new Customer { Name = "Aneta", Id = 2 },
               new Customer { Name = "Marek", Id = 3 }
               };
        }
    }
}