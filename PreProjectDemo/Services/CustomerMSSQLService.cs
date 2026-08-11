using PreProjectDemo.Data;
using PreProjectDemo.ViewModel;
using PreProjectDemo.Models;
namespace PreProjectDemo.Services
{
    public class CustomerMSSQLService : ICustomerService
    {
        private readonly PreProjectDemoContext _context;

        public CustomerMSSQLService(PreProjectDemoContext context)
        {
            _context = context;
        }

        public void AddCustomer(CustomerVM new_customer)
        {
            _context.Customers.Add(new Customer
            {
                Name = new_customer.Name,
                Age = new_customer.Age,
                Email = new_customer.Email,
                Phone = new_customer.Phone,
                IsMarried = new_customer.IsMarried,
                Gender = new_customer.Gender
            });

            _context.SaveChanges();
        }

        public List<CustomerVM> GetAllCustomers()
        {
            return _context.Customers.Select(c => new CustomerVM
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email,
                Phone = c.Phone,
                IsMarried = c.IsMarried,
                Gender = c.Gender
            }).ToList();
        }
    }
}
