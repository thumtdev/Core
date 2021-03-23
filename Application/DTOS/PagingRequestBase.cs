using System.Collections.Generic;

namespace Application.DTOS
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}