

namespace Entity.Paging
{
   public class RequestPrameters
    {
        private int _maxSize=50;
        private int _pageSize = 1;
        public int pageSize { 
            get 
            {
                return _pageSize;
            }
            set {
              _pageSize=_maxSize < value ? _maxSize : value;
            } 
        }
        public int pageIndex { get; set; }
        public string OrderString { get; set; }

    }
    public class cityRequestPrameters: RequestPrameters
    {

    }
}
