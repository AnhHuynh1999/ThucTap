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
    //[Authorize(Roles = RoleNguoiSuDung.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        DuAnBO dabo;
        public DuAnController(DuAnBO bo)
        {
            dabo = bo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dabo.GetAll());
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
               
                    return Ok(dabo.Delete(id));
               
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(dabo.GetByID(id));
        }
        [HttpPut]
        public IActionResult Update([FromBody] DuAn duanmoi)
        {
            try
            {
              
                    return Ok(dabo.Update(duanmoi));
           
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody]DuAn duanmoi)
        {
            try
            {
                return Ok(dabo.Add(duanmoi));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
