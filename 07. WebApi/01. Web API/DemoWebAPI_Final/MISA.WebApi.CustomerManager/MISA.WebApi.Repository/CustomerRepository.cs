using MISA.WebApi.Modal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MISA.WebApi.Repository
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork uow)
            : base(uow)
        {

        }
        public BaseRepository<Customer> _baseRepository;

        /// <summary>
        /// Lấy danh sách toàn bộ khách hàng
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            customers = GetListObject<Customer>("Proc_GetListCustomer");
            return customers;
        }

        public IEnumerable<Customer> GetPersonDetails()
        {
            return GetAll().AsEnumerable();
        }

        public int InsertPersonDetails(Customer customer)
        {
            return Insert(customer);
        }
        /// <summary>
        /// Lấy thông tin khách hàng theo mã khách hàng
        /// </summary>
        /// <param name="customerID">Mã khách hàng</param>
        /// <returns></returns>
        /// Created by: NVMANH (02/08/2017)
        public Customer GetCustomerByCustomerID(Guid customerID)
        {
            return GetObjectByObjectID<Customer>(customerID);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">khách hàng</param>
        /// <returns></returns>
        /// Created by: NVMANH (02/08/2017)
        public int InsertCustomer(Customer customer)
        {
            return InsertObject<Customer>(customer);
        }

        /// <summary>
        /// Cập nhật thông tin khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// Created by: NVMANH (02/08/2017)
        public int UpdateCustomer(Customer customer)
        {
            return UpdateObject<Customer>(customer);
        }

        public int DeleteCustomerByID(Guid customer)
        {
            return DeleteObjectByID<Customer>(customer);
        }
    }
}
