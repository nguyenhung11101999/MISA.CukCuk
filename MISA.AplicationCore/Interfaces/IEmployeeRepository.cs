using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IEmployeeRepository 
    {
        /// <summary>
        /// Lấy danh sách khách hàng
        /// Danh sách khách hàng
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid employeeId);
        int AddEmployee(Employee employee);
        int UpdateEmployee(Employee employee);
        int DeleteEmployee(Guid employeeId);
        Employee GetEmployeeByCode(string employeeCode);

    }
}
