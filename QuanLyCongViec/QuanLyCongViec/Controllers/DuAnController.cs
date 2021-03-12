using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyCongViec.Controllers
{
    [Authorize(Roles = RoleNguoiSuDung.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        //private readonly IMemoryCache memory;
        DuAnBO dabo;
        public DuAnController(DuAnBO bo)
        {
            dabo = bo;
           // memory = memoryCache;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(dabo.GetAll());
        }
        //[HttpGet]
        //public async Task<IActionResult> GetAll()
        //{
        //    var cachekey = "listDuAn";
        //    if(!memory.TryGetValue(cachekey, out List<DuAn> DuAnList))
        //    {
        //        DuAnList = await dabo.GetAll();
        //        var cacheExpiryOptions = new MemoryCacheEntryOptions
        //        {
        //            AbsoluteExpiration = DateTime.Now.AddMinutes(5),
        //            Priority = CacheItemPriority.High,
        //            SlidingExpiration = TimeSpan.FromMinutes(2)
        //        };
        //        memory.Set(cachekey, DuAnList, cacheExpiryOptions);
        //    }
        //    return Ok(DuAnList);
        //}


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


        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromBody] DuAn duanmoi)
        {
            try
            {
                return Ok(dabo.Update(id,duanmoi));
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
