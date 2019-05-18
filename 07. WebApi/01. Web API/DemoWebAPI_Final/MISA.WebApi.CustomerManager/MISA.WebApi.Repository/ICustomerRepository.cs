using MISA.WebApi.Modal;
using System;
using System.Collections.Generic;

namespace MISA.WebApi.Repository
{
    public interface ICustomerRepository: IRepository<Customer>
    {
        List<Customer> GetCustomers();
        Customer GetCustomerByCustomerID(Guid customerID);
        int InsertCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomerByID(Guid customer);
    }
}
