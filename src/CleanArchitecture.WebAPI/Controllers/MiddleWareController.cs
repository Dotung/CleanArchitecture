using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiddleWareController : ControllerBase
    {
        [HttpGet]
        public IActionResult DemoGetValueQueryString(string par1,string par2)
        {
            var dicOutput = HttpContext.Request.Headers.Where(c => c.Key == "par1" || c.Key == "par2").Select(c => new
            {
                Key = c.Key,
                Value = c.Value.ToString()
            }).ToDictionary(x => x.Key, x => x.Value);

            var data = JsonConvert.SerializeObject(dicOutput);
            return new JsonResult(data);
        }
    }
}