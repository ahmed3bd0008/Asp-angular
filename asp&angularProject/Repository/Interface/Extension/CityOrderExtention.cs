using Repository.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace Repository.Interface.Extension
{
  public static  class OrderExtention
    {
        public static IEnumerable<T>EntityOrder<T>(this IEnumerable<T>Entities,string OrderString)
        {
            if (string.IsNullOrEmpty(OrderString))
                return Entities;
            var OrderStringQuery = OrderQuery.BuildOrderQuery<T>(OrderString);
            if (string.IsNullOrEmpty(OrderStringQuery))
                return Entities;
            return Entities.AsQueryable().OrderBy(OrderStringQuery);
        }
    }
}
