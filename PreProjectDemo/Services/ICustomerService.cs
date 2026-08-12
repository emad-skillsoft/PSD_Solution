using PreProjectDemo.Models;
using PreProjectDemo.ViewModel;

namespace PreProjectDemo.Services
{
    public interface ICustomerService
    {
        List<CustomerVM> GetAllCustomers();

        void AddCustomer(CustomerVM new_customer);

        bool UpdateCustomer(CustomerVM new_customer);

        CustomerVM? GetCustomerById(int id);
        
        bool DeleteCustomer(int id);

    }
}
