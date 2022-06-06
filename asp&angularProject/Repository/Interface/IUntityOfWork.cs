using Entity.Core;
using Entity.Core.world;
using Repository.Implementation;
using System;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUntityOfWork:IDisposable
    {
        public GenericPagedRepository<City> CityRepo{ get; }
        public GenericRepository<Countery> CounteryRepo{ get; }
        public int save();
        public Task< int> saveASync();

    }
}