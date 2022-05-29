using AutoMapper;
using Entity.Core.world;
using Entity.Dto.worldDTO;
using Repository.Interface;
using Services.Interface;
using Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class WorldService : IWorldService
    {
        private readonly IUntityOfWork _untityOfWork;
        private readonly IMapper _mapper;

        public WorldService(IUntityOfWork untityOfWork,IMapper mapper )
        {
            _untityOfWork = untityOfWork;
            _mapper = mapper;
        }
        public ServiceResponse<int> AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _untityOfWork.CityRepo.AddEntity(city);
            _untityOfWork.sa
        }

        public ServiceResponse<int> AddCountery(CounteryDto cityDto)
        {
            throw new NotImplementedException();
        }
    }
}
