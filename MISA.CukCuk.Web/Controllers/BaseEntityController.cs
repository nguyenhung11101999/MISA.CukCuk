using Microsoft.AspNetCore.Mvc;
using MISA.AplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public abstract class BaseEntityController<T> : ControllerBase
    {
        IBaseService<T> _baseService;
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        /// <summary>
        /// Lấy toàn bộ khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CretedBY: NMHung (10/02/2021)
        [HttpGet]
        public IActionResult Get()
        {
            var entities = _baseService.GetTs();
            return Ok(entities);
        }

        /// <summary>
        /// Lấy danh sách khách hàng theo id và tên
        /// </summary>
        /// <param name="id">id của khách hàng</param>
        /// <param name="name">tên của khách hàng</param>
        /// <returns>Danh sách khách hàng</returns>
        /// CretedBY: NMHung (10/02/2021)
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var entity = _baseService.GetTById(Guid.Parse(id));
            return Ok(entity);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public IActionResult Post(T entity)
        {
            var serviceResult = _baseService.Add(entity);
            if (serviceResult.MISACode == AplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else 
            {
                return Ok(serviceResult);
            }
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]string id, [FromBody] T entity)
        {
            var keyProperty = entity.GetType().GetProperty($"{typeof(T).Name}Id");
            if(keyProperty.PropertyType == typeof(Guid))
            {
                keyProperty.SetValue(entity, Guid.Parse(id));
            }
            else
            {
                if (keyProperty.PropertyType == typeof(int))
                {
                    keyProperty.SetValue(entity, int.Parse(id));
                }
                else
                {
                    keyProperty.SetValue(entity, id);
                }
            }
            var serviceResult = _baseService.Update(entity);
            if (serviceResult.MISACode == AplicationCore.Enums.MISACode.NotValid)
            {
                return BadRequest(serviceResult);
            }
            else
            {
                return Ok(serviceResult);
            }
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            return Ok(res);
        }
    }
}
