using Entity.Core.world;
using Entity.Paging;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
   public class CityRepository : GenericPagedRepository<City>, ICityRepository
    {
       private readonly AppDbContextTest _context;
        public CityRepository(AppDbContextTest context) :base(context)
        {
            _context = context;
        }
        public List<City> cities()
        {
            var cities= _context.Cities.Include(d => d.Countery);
            return cities.ToList();
        }

        
    }
}
