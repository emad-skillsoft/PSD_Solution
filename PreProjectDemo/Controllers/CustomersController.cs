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

    //// GET: CUSTOMERS/Details/5
    //public async Task<IActionResult> Details(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var customer = await _context.Customers
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (customer == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(customer);
    //}

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

    //// GET: CUSTOMERS/Edit/5
    //public async Task<IActionResult> Edit(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var customer = await _context.Customers.FindAsync(id);
    //    if (customer == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(customer);
    //}

    //// POST: CUSTOMERS/Edit/5
    //// To protect from overposting attacks, enable the specific properties you want to bind to.
    //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //[HttpPost]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> Edit(int? id, [Bind("Id,Name,Age,Email,Phone,IsMarried,Gender")] Customer customer)
    //{
    //    if (id != customer.Id)
    //    {
    //        return NotFound();
    //    }

    //    if (ModelState.IsValid)
    //    {
    //        try
    //        {
    //            _context.Update(customer);
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!CustomerExists(customer.Id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }
    //        return RedirectToAction(nameof(Index));
    //    }
    //    return View(customer);
    //}

    //// GET: CUSTOMERS/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var customer = await _context.Customers
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (customer == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(customer);
    //}

    //// POST: CUSTOMERS/Delete/5
    //[HttpPost, ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int? id)
    //{
    //    var customer = await _context.Customers.FindAsync(id);
    //    if (customer != null)
    //    {
    //        _context.Customers.Remove(customer);
    //    }

    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}

    //private bool CustomerExists(int? id)
    //{
    //    return _context.Customers.Any(e => e.Id == id);
    //}
}
