using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSDWebApp.Services;
using PSDWebApp.Models;

namespace PSDWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService; 
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerService.Customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
           var customer = _customerService.Customers.FirstOrDefault(c => c.Id == id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Customer customer)
        {
            try
            {
                _customerService.Customers.Add(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.Customers.FirstOrDefault(c => c.Id == id);

            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] Customer customer   )
        {
            try
            {
                var existingCustomer = _customerService.Customers.FirstOrDefault(c => c.Id == id);

                existingCustomer.Name = customer.Name;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var existingCustomer = _customerService.Customers.FirstOrDefault(c => c.Id == id);

            return View(existingCustomer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] Customer customer )
        {
            try
            {

                var existingCustomer = _customerService.Customers.FirstOrDefault(c => c.Id == id);
                _customerService.Customers.Remove(existingCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
