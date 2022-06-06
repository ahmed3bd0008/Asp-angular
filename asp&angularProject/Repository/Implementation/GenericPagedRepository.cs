using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entity.Core.world;
using Entity.Paging;
using Entity.Shared;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Interface;

namespace Repository.Implementation
{
    public class GenericPagedRepository<T> : GenericRepository<T> , IGenericPagedRepository<T> where T : EntityId 
    {
        private readonly AppDbContextTest _context;
        private readonly DbSet<T> _entity;

        public GenericPagedRepository(AppDbContextTest context) : base(context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<PageList<T>> GetPagedListAsync(int pageIndex, int pageSize)
        {
            return await PageList<T>.ToPageListAsync(_entity.AsQueryable(), pageIndex, pageSize); 
        }
    }
}
