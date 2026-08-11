using PreProjectDemo.Models;
using PreProjectDemo.ViewModel;

namespace PreProjectDemo.Services
{
    public interface ICustomerService
    {
        List<CustomerVM> GetAllCustomers();

        void AddCustomer(CustomerVM customer);

    }
}
