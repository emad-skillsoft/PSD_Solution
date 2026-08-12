using PreProjectDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreProjectDemo.Models;
using PreProjectDemo.Services;
using PreProjectDemo.ViewModel;

public class CustomersController : Controller
{
    private readonly ICustomerService _customerservice;

    public CustomersController(ICustomerService customerservice)
    {
        _customerservice = customerservice;
    }

    // GET: CUSTOMERS
    public  IActionResult Index()    
    {
        return View(_customerservice.GetAllCustomers());
    }

    // GET: CUSTOMERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        CustomerVM customer = _customerservice.GetCustomerById(id.Value);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // GET: CUSTOMERS/Create
    public IActionResult Create()
    {
        return View(new CustomerVM());
    }

    // POST: CUSTOMERS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([FromForm] CustomerVM customer)
    {
        if (ModelState.IsValid)
        {
            _customerservice.AddCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    // GET: CUSTOMERS/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        CustomerVM customer = _customerservice.GetCustomerById(id.Value);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    // POST: CUSTOMERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, [FromForm] CustomerVM customer)
    {
        if (id != customer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {

            _customerservice.UpdateCustomer(customer);

            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }

    // GET: CUSTOMERS/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        CustomerVM customer = _customerservice.GetCustomerById(id.Value);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: CUSTOMERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
        _customerservice.DeleteCustomer(id.Value);
        return RedirectToAction(nameof(Index));
    }

}
