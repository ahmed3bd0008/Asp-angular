using System;
using Entity.Shared;
namespace Entity.Core.world
{
    public class City:EntityName
    {
        public string Name_ASCII { get; set; }
        public Decimal Lat { get; set; }
        public Decimal Lon { get; set; }
        public Guid CounteryId { get; set; }
        public Countery Countery { get; set; }
    }
}