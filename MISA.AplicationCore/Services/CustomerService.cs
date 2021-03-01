using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;
using MISA.AplicationCore.Interfaces;
using MISA.AplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        ICustomerRepository _customerRepository;
        #region Constructor
        public CustomerService( ICustomerRepository customerRepository) :base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        #endregion
        #region Method

        protected override bool ValidateEntity(Customer entity)
        {
            return true;
        }
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomerByGroup(Guid departmentId)
        {
            throw new NotImplementedException();
        }
        //Sửa thông tin khách hàng

        //Xóa khách hàng
        #endregion
    }
}
