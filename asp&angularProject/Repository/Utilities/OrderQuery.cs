using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Repository.Utilities
{
  public static  class OrderQuery
    {
        public static string BuildOrderQuery<T>(string orderstring)
        {
            var orderStringParms = orderstring.Trim().Split(',', StringSplitOptions.RemoveEmptyEntries);
            PropertyInfo[] PropertiesInfo = typeof(T).GetProperties( BindingFlags.Public| BindingFlags.Instance|BindingFlags.IgnoreCase);
            StringBuilder stringQuery = new();
            foreach (var item in orderStringParms)
            {
                var parms = item.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                if (string.IsNullOrWhiteSpace(parms))
                    continue;
                var prop = PropertiesInfo.FirstOrDefault(p => p.Name.Equals(parms, System.StringComparison.InvariantCultureIgnoreCase));
                if (prop == null)
                    continue;
                var direct = parms.EndsWith(" desc") ? "descending" : "ascending";
                stringQuery.Append($"{prop.Name} {direct} ,");
            }
            //delete last ,
            return stringQuery.ToString().TrimEnd(',', ' ');
        }
    }
}
