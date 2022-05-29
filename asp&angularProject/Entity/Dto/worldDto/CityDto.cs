using System;
using Entity.Shared;
namespace Entity.Dto.worldDTO
{
    public class CityDto
    {
        public string Name { get; set; }
        public string Name_ASCII { get; set; }
        public Decimal Lat { get; set; }
        public Decimal Lon { get; set; }
        public Guid CounteryId { get; set; }
       
    }
}