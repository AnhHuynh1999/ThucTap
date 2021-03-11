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
    [Authorize(Roles =RoleNguoiSuDung.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class QLNguoiSuDungController : ControllerBase
    {
        NguoiSuDungBO bo;
        public QLNguoiSuDungController (NguoiSuDungBO dungBO)
        {
            bo = dungBO;
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (id != null)
                return Ok(bo.delete(id));
            return BadRequest();
        }


        [HttpPut("{id}")]
        public IActionResult Update([FromBody]NguoiSuDung nguoisudung, string id)
        {
            if (id != null)
                return Ok(bo.Update(nguoisudung));
            return BadRequest();
        }


        [HttpPost]
        public IActionResult Add(NguoiSuDung nguoi)
        {
            return Ok(bo.Add(nguoi));
        }
    }
}
