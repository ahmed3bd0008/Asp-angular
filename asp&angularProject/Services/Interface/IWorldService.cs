using Entity.Dto.worldDTO;
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
        public ServiceResponse<int> AddCountery(CounteryDto cityDto);
        public ServiceResponse<List<GetCounteryDto>> GetCountery();
    }
}
