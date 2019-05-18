using MISA.WebApi.Modal;
using MISA.WebApi.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft;
using Newtonsoft.Json;
using System;

namespace MISA.WebApi.CustomerManager.Controllers
{
    [RoutePrefix("/api/Customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _CustomerService;
        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        /// Created by: NVMANH (01/03/2017)
        [HttpGet]
        public HttpResponseMessage GetCustomers()
        {
            List<Customer> customer = _CustomerService.GetCustomers();
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        // POST api/default1
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="value"></param>
        /// Created by: NVMANH (01/03/2018)
        [HttpPost]
        public void InsertNewCustomer(Customer customer)
        {
            _CustomerService.InsertCustomer(customer);
        }

        /// <summary>
        /// Sửa thông tin khách hàng
        /// </summary>
        /// <param name="id">Mã khách hàng</param>
        /// <param name="value">chuỗi json</param>
        /// Created by: NVMANH (01/03/2018)
        [HttpPut]
        public void UpdateCustomer(int id, [FromBody]Customer value)
        {
            //Customer customer = JsonConvert.DeserializeObject<Customer>(value);
            _CustomerService.UpdateCustomer(value);
        }

        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// Created by: NVMANH (01/03/2018)
        [HttpDelete]
        public void DeleteCustomer([FromBody]string id)
        {
            _CustomerService.DeleteCustomer(Guid.Parse(id));
        }
    }
}
