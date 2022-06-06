using Entity.Dto.worldDTO;
using Entity.Paging;
using Services.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
 public   interface IWorldService
    {
        public ServiceResponse<int> AddCity(CityDto cityDto);
        public ServiceResponse<List<GetCityDto>> GetCity();
        public ServiceResponse<PageList<GetCityDto>> GetCityPaging(int pageSize,int  PageIndex);
        public Task< ServiceResponse<PageList<GetCityDto>> >GetCityPagingAsync(int pageSize, int PageIndex);
        public Task<ServiceResponse<List<GetCityDto>>> GetCityAsync();
        public ServiceResponse<int> AddCountery(CounteryDto cityDto);
        public ServiceResponse<List<GetCounteryDto>> GetCountery();
    }
}
