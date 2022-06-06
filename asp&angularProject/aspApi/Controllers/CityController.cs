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
    public class CityController : ControllerBase
    {
        private readonly IWorldService _worldService;

        public CityController(IWorldService worldService)
        {
            _worldService = worldService;
        }
        [HttpPost("CreateCity")]
        public IActionResult CreateCity(CityDto cityDto) 
        {
            return Ok(_worldService.AddCity(cityDto));
        }
        [HttpGet]
        public IActionResult GetCity( )
        {
            return Ok(_worldService.GetCity());
        }
        [HttpGet]
        [Route("GetCityWithInclude")]
        public async  Task<IActionResult> GetCityAsync()
        {
            return Ok(await _worldService.GetCityAsync());
        }
        [HttpGet]
        [Route("GetCityPaging/{pageSize?}/{pageIndex?}")]
        public async Task<IActionResult> GetCityPagingAsync(int pageSize, int pageIndex)
        {
            return Ok(await _worldService.GetCityPagingAsync(pageSize, pageIndex));
        }

    }
}
