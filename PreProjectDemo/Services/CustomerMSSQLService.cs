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

        public CustomerVM? GetCustomerById(int id)
        {
            

            return _context.Customers.Where(c => c.Id == id).Select(c => new CustomerVM
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Email = c.Email,
                Phone = c.Phone,
                IsMarried = c.IsMarried,
                Gender = c.Gender
            }).FirstOrDefault();
        }   

        public bool UpdateCustomer(CustomerVM new_customer)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.Id == new_customer.Id);
            
            if (customer == null)
                return false;

            customer.Name = new_customer.Name;
            customer.Age = new_customer.Age;
            customer.Email = new_customer.Email;
            customer.Phone = new_customer.Phone;
            customer.IsMarried = new_customer.IsMarried;
            customer.Gender = new_customer.Gender;

            _context.SaveChanges();
            return true;    
        }
    }
}
