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
        private readonly ICityRepository _cityRepository;

        public WorldService(IUntityOfWork untityOfWork,IMapper mapper ,ICityRepository cityRepository)
        {
            _untityOfWork = untityOfWork;
            _mapper = mapper;
            _cityRepository = cityRepository;
        }
        public ServiceResponse<int> AddCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _untityOfWork.CityRepo.AddEntity(city);
            int res= _untityOfWork.save();
            if (res <= 0)
                return new ServiceResponse<int>() { Status = false, Message = "No date save" };
            return new ServiceResponse<int>() { Status = true, Date=res,Message="Data Save"};

        }
        public ServiceResponse<List<GetCityDto>> GetCity()
        {
            var Cities = _untityOfWork.CityRepo.getEntityWithInclude(filter:null,orderBy:null,x=>x.Countery);
            var cityDto = _mapper.Map<List<GetCityDto>>(Cities);
            return new ServiceResponse<List<GetCityDto>>() { Date = cityDto, Message = "Date" };

        }


        public ServiceResponse<int> AddCountery(CounteryDto counteryDto)
        {
            var Countery = _mapper.Map<Countery>(counteryDto);
            _untityOfWork.CounteryRepo.AddEntity(Countery);
            int res = _untityOfWork.save();
            if (res <= 0)
                return new ServiceResponse<int>() { Status = false, Message = "No date save" };
            return new ServiceResponse<int>() { Status = true, Date = res, Message = "Data Save" };
        }

       
        public ServiceResponse<List<GetCounteryDto>> GetCountery()
        {
          var Counteries = _untityOfWork.CounteryRepo.getEntityWithInclude(null, d => d.OrderBy(o => o.Name), x=>x.Cities);
            var counteryDto = _mapper.Map<List<GetCounteryDto>>(Counteries);
            return new ServiceResponse<List<GetCounteryDto>>() { Date = counteryDto, Message = "Date" };
        }

        protected virtual void Dispose(bool disposing)
        {
            _untityOfWork.Dispose();
            
        }
    }
}
