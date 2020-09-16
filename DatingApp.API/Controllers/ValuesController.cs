using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Controllers
{
    //http:localhost:5000/api/values      values call ValuesController
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            //ใช้ async ต้องเติม Task<..> และ await กับ ...Async()
            var values = await _context.Values.ToListAsync();
            //ดึงข้อมูลใน db ทั้งหมดมาแสดง
            return Ok(values);
            
            //throw new Exception("Test Exeption"); ดูรายละเอียดในการส่งข้อมูลมั้ง
            //return new string[] { "value1", "value3" };
        }

        // GET api/values/5
        //get record
        //อันนี้จะ return คำว่า values ออกไปถ้ามีการ /id คือมีการ /ตัวเลขตามหลัง api/values ไป
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {
            //จะ return ข้อมูลตาม id ออกไปที่มีใน database จะ return ข้อมูลตาม row 
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(value);
            //return "value";
        }

        // POST api/values
        //create record
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        //edit record
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        //delete record
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
