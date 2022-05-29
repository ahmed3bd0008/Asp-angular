using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Response
{
  public  class ServiceResponse<T>
    {
        public bool Status { get; set; }
        public string Message  { get; set; }
        public T Date { get; set; }
    }
}
