﻿using Entity.Dto.worldDTO;
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

    }
}
