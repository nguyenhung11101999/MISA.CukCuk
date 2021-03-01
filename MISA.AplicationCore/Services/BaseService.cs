using MISA.AplicationCore.Entities;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.AplicationCore.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        IBaseRepository<T> _baseRepository;
        ServiceResult _serviceResult;
        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { MISACode = Enums.MISACode.Success };
        }
        public virtual ServiceResult Add(T entity)
        {
            entity.EntityState = Enums.EntityState.AddNew;
            //thực hiện validate:
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Add(entity);
                _serviceResult.MISACode = Enums.MISACode.isValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }

        public ServiceResult Delete(Guid entityId)
        {
            _serviceResult.Data = _baseRepository.Delete(entityId);
            return _serviceResult;
        }

        public T GetTById(Guid entityId)
        {
            return _baseRepository.GetTById(entityId);
        }

        public IEnumerable<T> GetTs()
        {
            return _baseRepository.GetTs();
        }

        public ServiceResult Update(T entity)
        {
            entity.EntityState = Enums.EntityState.Update;
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                _serviceResult.Data = _baseRepository.Update(entity);
                _serviceResult.MISACode = Enums.MISACode.isValid;
                return _serviceResult;
            }
            else
            {
                return _serviceResult;
            }
        }
        private bool Validate(T entity)
        {
            var mesArrayErro = new List<string>();
            var isValidate = true;
            var serviceResult = new ServiceResult();
            //Đọc các Property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(entity);
                var displayName = string.Empty;
                var displayNameAttributes = property.GetCustomAttributes(typeof(DisplayName), true);
                if(displayNameAttributes.Length > 0)
                {
                    displayName = (displayNameAttributes[0] as DisplayName).Name;
                }
                //Kiểm tra xem có Attribute cần phải validate không:
                if (property.IsDefined(typeof(Required), false))
                {
                    //Check bắt buộc nhập:
                    if (propertyValue == null)
                    {
                        isValidate = false;
                        mesArrayErro.Add(string.Format(Properties.Resources.Msg_Duplicate, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = "Dữ liệu không hợp lệ.";
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //Check trùng dữ liệu:
                    var propertyName = property.Name;
                    var entityDupliacte = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDupliacte != null)
                    {
                        isValidate = false;
                        mesArrayErro.Add(string.Format(Properties.Resources.Msg_Duplicate, displayName));
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    //Lấy độ dài đã khai báo
                    
                    var attributeMaxLength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxLength as MaxLength).Value;
                    var msg = (attributeMaxLength as MaxLength).ErroMsg;
                    if(propertyValue.ToString().Trim().Length > length)
                    {
                        isValidate = false;
                        mesArrayErro.Add(msg??$"Thông tin này vượt quá {length} ký tự cho phép");
                        _serviceResult.MISACode = Enums.MISACode.NotValid;
                        _serviceResult.Messenger = Properties.Resources.Msg_IsNotValid;
                    }
                }
            }
            _serviceResult.Data = mesArrayErro;
            if (isValidate == true)
            {
                isValidate = ValidateEntity(entity);
            }
            return isValidate;
        }
        /// <summary>
        /// Hàm thực hiện kiểm tra dữ liệu/ Nghiệp vụ tùy chỉnh
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateEntity(T entity)
        {
            return true;
        }
    }
}
