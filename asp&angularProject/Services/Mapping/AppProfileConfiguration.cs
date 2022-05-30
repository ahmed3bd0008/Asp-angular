using AutoMapper;
using Entity.Core.world;
using Entity.Dto.worldDTO;

namespace Services.Mapping
{
    public class AppProfileConfiguration:Profile
    {
         public AppProfileConfiguration()
         {
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CounteryDto, Countery>().ReverseMap();
            CreateMap<GetCounteryDto, Countery>().ReverseMap();
            CreateMap<City, GetCityDto>().ForMember(d=>d.getCounteryDto,o=>o.MapFrom(d=>d.Countery))

           . ReverseMap();
           
            
        }
    }
}