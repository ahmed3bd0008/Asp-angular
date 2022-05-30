using Entity.Core;
using Entity.Core.world;
using Repository.Context;
using Repository.Interface;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class UntityOfWork : IUntityOfWork
    {
        private readonly AppDbContextTest _context;
        private GenericRepository<City> _cityRepo;
        private GenericRepository<Countery> _counteryRepo;

        public UntityOfWork(AppDbContextTest contextTest)
        {
            _context = contextTest;
        }

        public GenericRepository<City> CityRepo
        {
            get
            {
                if (_cityRepo == null)
                    _cityRepo = new GenericRepository<City>(_context);

                return _cityRepo;
            }
        }
        public GenericRepository<Countery> CounteryRepo
        {
            get
            {
                if (_cityRepo == null)
                    _counteryRepo = new GenericRepository<Countery>(_context);

                return _counteryRepo;
            }
        }
        public bool disposed { get; set; } = false;

        
       

        public int save()
        {
          return  _context.SaveChanges();
        }

        public async Task< int> saveASync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}