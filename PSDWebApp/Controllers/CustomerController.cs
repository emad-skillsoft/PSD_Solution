using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSDWebApp.Services;
using PSDWebApp.ViewModel;


namespace PSDWebApp.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
            
        }

    

        // GET: CustomerController
        public ActionResult Index()
        {
            return View(_customerService.GetCustomers());
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerService.GetCustomerDetailById(id);

            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
               
            return View(new CustomerAddVM());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CustomerAddVM customer)
        {
            try
            {
                _customerService.AddNewCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerForEditById(id);

            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] CustomerEditVM customer)
        {
            try
            {
                _customerService.UpdateCustomerById(id, customer);

                

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
            var customer = _customerService.GetCustomerForDeleteById(id);

            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [FromForm] CustomerDeleteVM customer)
        {
            try
            {

                _customerService.DeleteCustomerById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(customer);
            }
        }
    }
}
