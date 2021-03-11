using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCongViec.Controllers

{

    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        NguoiDungBO bo;
        public NguoiDungController(NguoiDungBO nguoiDung)
        {
            bo = nguoiDung;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bo.GetAll());
        }

               
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(bo.GetByID(id));
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody] NguoiDung duanmoi, int id)
        {
            try
            {
                return Ok(bo.Update(duanmoi));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        public IActionResult Add([FromBody] NguoiDung ngmoi)
        {
            try
            {
                return Ok(bo.Add(ngmoi));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [Authorize(Roles = RoleNguoiSuDung.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(bo.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
