using Entity.Core;
using Entity.Core.world;
using Repository.Implementation;
using System;

namespace Repository.Interface
{
    public interface IUntityOfWork:IDisposable
    {
        public GenericRepository<City> CityRepo{ get; }
        public GenericRepository<Countery> CounteryRepo{ get; }

    }
}