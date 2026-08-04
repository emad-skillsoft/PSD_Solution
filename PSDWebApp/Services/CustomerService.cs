using PSDWebApp.Models;

namespace PSDWebApp.Services
{
    public class CustomerService
    {
        public List<Customer> Customers { get; set; }

        public CustomerService()
        {
            Customers = new List<Customer>()
            {

                new Customer { Id = 1, Name = "Emad" }
            };
        }
    }
}
