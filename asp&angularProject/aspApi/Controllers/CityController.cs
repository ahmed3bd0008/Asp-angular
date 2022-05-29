using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUntityOfWork _untityOfWork;

        public CityController(IUntityOfWork untityOfWork)
        {
            _untityOfWork = untityOfWork;
        }
        [HttpPost("CreateCity")]
        public IActionResult CreateCity() 
        {
            return Ok();
        }
    }
}
