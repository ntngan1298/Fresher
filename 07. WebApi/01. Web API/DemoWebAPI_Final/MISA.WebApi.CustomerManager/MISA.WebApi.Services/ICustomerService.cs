using MISA.WebApi.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebApi.Services
{
    public interface ICustomerService:IEntityService<Customer>
    {
        List<Customer> GetCustomers();
        Customer GetCustomerByCustomerID(Guid customerID);
        int InsertCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(Guid customerID);
    }
}
