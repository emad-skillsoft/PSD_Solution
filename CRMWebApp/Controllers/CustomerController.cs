using CRMWebApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRMWebApp.Models;
namespace CRMWebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerMemoryService _customerMemeoryService;

        //constructor
        public CustomerController(CustomerMemoryService service)
        {
            _customerMemeoryService = service;    
        }



        // GET: CustomerController
        public ActionResult Index()
        {
            
           
            ViewData["CompanyName"] = "Global Knowledge";
            return View(_customerMemeoryService.Customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            Customer? cust=_customerMemeoryService.Customers.FirstOrDefault(custObj => custObj.Id==id   );

            return View(cust);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            Customer cust = new Customer() { Id = _customerMemeoryService.Customers.Count + 1 };
            return View(cust);
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer cust)
        {
            try
            {
                _customerMemeoryService.Customers.Add(cust);
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
            Customer? cust = _customerMemeoryService.Customers.FirstOrDefault(custObj => custObj.Id == id);
            return View(cust);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer cust)
        {
            try
            {
                Customer? custobj = _customerMemeoryService.Customers.FirstOrDefault(custObj => custObj.Id == id);
                custobj.Name = cust.Name;
                custobj.Age = cust.Age;
                custobj.Email = cust.Email;
                custobj.Phone = cust.Phone;
               
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            Customer? cust = _customerMemeoryService.Customers.FirstOrDefault(custObj => custObj.Id == id);
            return View(cust);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer cust)
        {
            try
            {
                Customer? custobj = _customerMemeoryService.Customers.FirstOrDefault(custObj => custObj.Id == id);
                _customerMemeoryService.Customers.Remove(custobj);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
