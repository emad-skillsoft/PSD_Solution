using CRMWebApp.Models;

namespace CRMWebApp.Services
{
    public class CustomerMemoryService
    {
        public List<Customer> Customers { get; set; }

        public CustomerMemoryService()
        {
            Customers = new List<Customer>()
                {
                    new Customer(){
                        Id = 1,
                        Age=55,
                        Name="Emad El Faramawi",
                        Email="emad@example.com",
                        Phone="111-222-333"

                    }

                };
        }
    }
}
