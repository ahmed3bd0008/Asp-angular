using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Core.world;
using Entity.Paging;
using Entity.Shared;

namespace Repository.Interface
{
    public interface IGenericPagedRepository<T> where T : EntityId
    {
        public Task<PageList<T>> GetPagedListAsync(int pageIndex,int pageSize);
    }
}
