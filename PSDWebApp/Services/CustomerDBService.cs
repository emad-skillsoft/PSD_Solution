using PSDWebApp.Data;
using PSDWebApp.Models;
using PSDWebApp.ViewModel;

namespace PSDWebApp.Services
{
    public class CustomerDBService : ICustomerService
    {
        private readonly PSDWebAppContext _context;

        public CustomerDBService(PSDWebAppContext context)
        {
            _context = context;
        }

        public List<CustomerListVM> GetCustomers()
        {
            
            return _context.Customer.Select(c => new CustomerListVM
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

        public CustomerDetailVM GetCustomerDetailById(int id)
        {
            var customer = _context.Customer.FirstOrDefault(m => m.Id == id);
            if (customer == null) return new CustomerDetailVM();

            return new CustomerDetailVM
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                IsMarried = customer.IsMarried,
                Gender = customer.Gender
            };
        }

        public bool UpdateCustomerById(int id, CustomerEditVM new_customer)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (customer == null) return false;

            customer.Name = new_customer.Name;
            customer.Age = new_customer.Age;
            customer.Email = new_customer.Email;
            customer.Phone = new_customer.Phone;
            customer.IsMarried = new_customer.IsMarried;
            customer.Gender = new_customer.Gender;
            
            _context.SaveChanges(); 
            return true;
        }

        public CustomerEditVM GetCustomerForEditById(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (customer == null) return new CustomerEditVM();

            return new CustomerEditVM
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                IsMarried = customer.IsMarried,
                Gender = customer.Gender
            };
        }

        public bool DeleteCustomerById(int id)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Id == id);
            if (customer == null) return false;

            _context.Customer.Remove(customer);
            _context.SaveChanges(   );
            return true ;
        }

        CustomerDeleteVM ICustomerService.GetCustomerForDeleteById(int id)
        {
            var customer = _context.Customer.FirstOrDefault (c => c.Id == id);
            if (customer == null) return new CustomerDeleteVM();

            return new CustomerDeleteVM
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                IsMarried = customer.IsMarried,
                Gender = customer.Gender
            };
        }

        public void AddNewCustomer(CustomerAddVM customer)
        {



            _context.Add(new Customer
            {
                Name = customer.Name,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                IsMarried = customer.IsMarried,
                Gender = customer.Gender
            });
            _context.SaveChanges();
        }
    }
}
