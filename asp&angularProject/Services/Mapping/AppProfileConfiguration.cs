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
        }
    }
}