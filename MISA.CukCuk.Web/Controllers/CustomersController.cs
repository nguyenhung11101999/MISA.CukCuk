using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MISA.AplicationCore;
using MISA.AplicationCore.Interfaces;
using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    /// <summary>
    /// API Danh mục khách hàng
    /// CreatedBY: NMHung (10/02/2021)
    /// </summary>
    public class CustomersController : BaseEntityController<Customer>
    {
        ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) :base(customerService)
        {
            _customerService = customerService;
        }
    }
}
