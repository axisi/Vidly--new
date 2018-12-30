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

            var Customers = _context.Customers.ToList();
            //var Customers = GetCustomers();//wczytywanie bez bazy danych
           
            return View(Customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);//wczytywanie bez bazy danych
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }
        // wczytywanie bez używania bazy danych
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer> {
        //       new Customer { Name = "Grzegorz", Id = 0 },
        //       new Customer { Name = "Klaudia", Id = 1 },
        //       new Customer { Name = "Aneta", Id = 2 },
        //       new Customer { Name = "Marek", Id = 3 }
        //       };
        //}
    }
}