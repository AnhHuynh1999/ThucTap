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
    public class CongViecController : ControllerBase
    {
        CongViecBO bo;
        public CongViecController(CongViecBO congViec)
        {
            bo = congViec;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bo.GetAll());
        }


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


        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            return Ok(bo.GetByID(id));
        }



        [HttpPut("{id}")]
        public IActionResult Update([FromBody] CongViec duanmoi, int id)
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
        public IActionResult Add([FromBody] CongViec cvmoi)
        {
            try
            {
                return Ok(bo.Add(cvmoi));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
