using PSDWebApp.Models;
using PSDWebApp.ViewModel;

namespace PSDWebApp.Services
{
    public class CustomerMemoryService : ICustomerService
    {
        private List<Customer> Customers { get; set; }

        public CustomerMemoryService()
        {
            Customers = new List<Customer>()
            {

                new Customer 
                { 
                    Id = 1, Name = "Emad", 
                    Age = 30, 
                    Email = "emad@example.com", 
                    Phone = "123-456-7890", 
                    IsMarried = false, 
                    Gender = Gender.Male     
                }
            };
        }

        public List<CustomerListVM> GetCustomers()
        {
            return Customers.Select(c => new CustomerListVM
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
            var customer = Customers.FirstOrDefault(c => c.Id == id);
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
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return false;

            customer.Name = new_customer.Name;
            customer.Age = new_customer.Age;
            customer.Email = new_customer.Email;
            customer.Phone = new_customer.Phone;
            customer.IsMarried = new_customer.IsMarried;
            customer.Gender = new_customer.Gender;

            return true;
        }

        public CustomerEditVM GetCustomerForEditById(int id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);
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
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null) return false;

            Customers.Remove(customer);
            return true ;
        }

        CustomerDeleteVM ICustomerService.GetCustomerForDeleteById(int id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);
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
            customer.Id = Customers.Max(c => c.Id) + 1;
            Customers.Add(new Customer
            {
                Id = customer.Id,
                Name = customer.Name,
                Age = customer.Age,
                Email = customer.Email,
                Phone = customer.Phone,
                IsMarried = customer.IsMarried,
                Gender = customer.Gender
            }); 
        }
    }
}
