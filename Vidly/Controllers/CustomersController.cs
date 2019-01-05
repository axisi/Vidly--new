using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;
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
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
                
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);  
            }
            else
            {
                var customerInDB = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDB,"",new string[] { "Name", "Email"});
                customerInDB.Name = customer.Name;
                customerInDB.BirthDate = customer.BirthDate;
                customerInDB.MembershipTypeId = customer.MembershipTypeId;
                customerInDB.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes,
                
                
            };
            return View("CustomerForm",viewModel);
        }
        // GET: Customers
        public ActionResult Index()
        {

            var Customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //var Customers = GetCustomers();//wczytywanie bez bazy danych
           
            return View(Customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);//wczytywanie bez bazy danych
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
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