using Entity.Core.world;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
 public   interface ICityRepository:IGenericRepository<City>
    {
        public List<City> cities();
    }
}
