using MISA.AplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Interfaces
{
    public interface IBaseService<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetTs();
        T GetTById(Guid entityId);
        ServiceResult Add(T entity);
        ServiceResult Update(T entity);
        ServiceResult Delete(Guid entityId);
    }
}
