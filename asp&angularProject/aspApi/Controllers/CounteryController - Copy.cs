using Entity.Dto.worldDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounteryController : ControllerBase
    {
        private readonly IWorldService _worldService;

        public CounteryController(IWorldService worldService)
        {
            _worldService = worldService;
        }
        [HttpPost("CreateCity")]
        public IActionResult CreateCountery(CounteryDto counteryDto) 
        {
            return Ok(_worldService.AddCountery(counteryDto));
        }
        [HttpGet]
        public IActionResult GetCountery()
        {
            return Ok(_worldService.GetCountery());
        }
    }
}
