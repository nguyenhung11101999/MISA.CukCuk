using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetTs();
        IEnumerable<T> GetTs(string storeName);
        T GetTById(Guid employeeId);
        int Add(T employee);
        int Update(T employee);
        int Delete(Guid employeeId);
        T GetEntityByProperty(T entity, PropertyInfo property);
    }
}
