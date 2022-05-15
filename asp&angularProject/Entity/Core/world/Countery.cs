using Entity.Shared;
using System.Collections.Generic;

namespace Entity.Core.world
{
    public class Countery:EntityName
    {
        public string ISO2 { get; set; }
        public string ISO3 { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}