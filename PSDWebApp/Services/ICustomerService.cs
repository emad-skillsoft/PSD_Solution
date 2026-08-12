using PSDWebApp.ViewModel;

namespace PSDWebApp.Services
{
    public interface ICustomerService
    {
        List<CustomerListVM> GetCustomers();
        CustomerDetailVM GetCustomerDetailById(int id);
        CustomerEditVM GetCustomerForEditById(int id);
        bool UpdateCustomerById(int id, CustomerEditVM new_customer);
        CustomerDeleteVM GetCustomerForDeleteById(int id);
        bool DeleteCustomerById(int id);
        void AddNewCustomer(CustomerAddVM customer);


    }
}
