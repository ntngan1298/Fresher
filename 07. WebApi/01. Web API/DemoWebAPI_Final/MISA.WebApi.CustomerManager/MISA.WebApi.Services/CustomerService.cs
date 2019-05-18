using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.WebApi.Modal;
using MISA.WebApi.Repository;

namespace MISA.WebApi.Services
{
    public class CustomerService : EntityService<Customer>, ICustomerService
    {
        IUnitOfWork _unitOfWork;
        ICustomerRepository _customerRepository;
        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository): base(unitOfWork, customerRepository)
        {
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }
        

        /// <summary>
        /// Lấy thông tin khách hàng theo mã khác hàng
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns></returns>
        /// Created by: NVMANH (02/03/2018)
        public Customer GetCustomerByCustomerID(Guid customerID)
        {
            return _customerRepository.GetCustomerByCustomerID(customerID);
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// Created by: NVMANH (02/03/2018)
        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// Created by: NVMANH (02/03/2018)
        public int InsertCustomer(Customer customer)
        {
            return _customerRepository.InsertCustomer(customer);
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// Created by: NVMANH (02/03/2016)
        public int UpdateCustomer(Customer customer)
        {
            return _customerRepository.UpdateCustomer(customer);
        }

        public int DeleteCustomer(Guid customerID)
        {
            return _customerRepository.DeleteCustomerByID(customerID);
        }
    }
}
