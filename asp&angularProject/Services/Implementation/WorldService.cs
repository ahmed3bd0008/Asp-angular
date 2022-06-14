using AutoMapper;
using Entity.Core.world;
using Entity.Dto.worldDTO;
using Entity.Paging;
using Repository.Interface;
using Repository.Interface.Extension;
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
            var Citiees = _cityRepository.cities();
            var cityDto = _mapper.Map<List<GetCityDto>>(Cities);
            return new ServiceResponse<List<GetCityDto>>() { Status = false, Date = cityDto, Message = "Date" };

        }
        public async Task<ServiceResponse<List<GetCityDto>>> GetCityAsync()
        {
            //var Cities = _untityOfWork.CityRepo.getEntityWithInclude(filter: null, orderBy: null, x => x.Countery);
            var Cities = await _untityOfWork.CityRepo.getEntityWithIncludeAsync("Countery", filter: null, orderBy: null);
          // var Citiees = _cityRepository.cities();
            var cityDto = _mapper.Map<List<GetCityDto>>(Cities);
            return new ServiceResponse<List<GetCityDto>>() {Status=true,  Date = cityDto, Message = "Date" };

        }

        public ServiceResponse<PageList<GetCityDto>> GetCityPaging(int pageSize, int PageIndex)
        {
            throw new NotImplementedException();
        }
        public async Task<ServiceResponse<PageList<CityDto>>> GetCityPagingOrderByAsync(cityRequestPrameters cityRequestPrameters)
        {
            var cities = _untityOfWork.CityRepo.getEntity(true).EntityOrder(cityRequestPrameters.OrderString);
            var cityPaging =  PageList<City>.ToPageList(cities.AsQueryable(), cityRequestPrameters.pageIndex, cityRequestPrameters.pageSize);
            var citiesDto = _mapper.Map<List<CityDto>>(cityPaging.Date);
            return new ServiceResponse<PageList<CityDto>>() { Date = new PageList<CityDto>(citiesDto, cityPaging.ItemCount, cityPaging.PageIndex, cityPaging.PageSize) };
        }

        public async Task< ServiceResponse<PageList<GetCityDto>>> GetCityPagingAsync(int pageSize, int PageIndex)
        {
            var c =await _untityOfWork.CityRepo.GetPagedListAsync(PageIndex, pageSize);
            var cities = _mapper.Map<List<GetCityDto>>(c.Date);
            return new ServiceResponse<PageList<GetCityDto>>() { Date = new PageList<GetCityDto>(cities, c.ItemCount, c.PageIndex, c.PageSize) };
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
          var Counteries = _untityOfWork.CounteryRepo.getEntityWithInclude(null, d => d.OrderBy(o => o.Name), x=>x.Cities).EntityOrder("Name dsc,isO2 desc");
            var counteryDto = _mapper.Map<List<GetCounteryDto>>(Counteries);
            return new ServiceResponse<List<GetCounteryDto>>() { Date = counteryDto, Message = "Date" };
        }

        protected virtual void Dispose(bool disposing)
        {
            _untityOfWork.Dispose();
            
        }

     
    }
}
