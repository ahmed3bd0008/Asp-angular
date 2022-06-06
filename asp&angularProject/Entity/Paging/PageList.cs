using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Paging
{
    public class PageList<T>
    {
        public PageList(List<T>sourse,int count,int PageIndex,int PageSize)
        {
           this.Date = sourse;
           this.ItemCount = count;
           this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.PageCount = (int)Math.Ceiling(count / (Double)PageSize);

        }
        public List<T> Date { get; set; }
        public bool HasPrevious { 
            get
            {
                return (PageIndex>1);
            }
             }
        public bool HasNext {
             get 
             {
                 return (PageIndex<PageCount);
             
             }
             }
        public int ItemCount { get; set; }
        public int PageCount { get; set; }
        public int PageIndex { get; set; }     
        public int PageSize { get; set; } 

        public static PageList<T> ToPageList(IQueryable<T> sourse,int PageIndex,int pageSize)
        {
            var date = sourse.Skip((PageIndex-1)*pageSize).Take(pageSize).ToList();
            var count = sourse.Count();
            return new PageList<T>(sourse: date, count: count, PageIndex: PageIndex, PageSize: pageSize);
        
        }
        public static async Task< PageList<T> >ToPageListAsync(IQueryable<T> sourse, int PageIndex, int pageSize)
        {
            var date =await sourse.Skip((PageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            var count =await sourse.CountAsync();
            return new PageList<T>(sourse: date, count: count, PageIndex: PageIndex, PageSize: pageSize);

        }

    }
}