using System.Collections.Generic;
using Application.DTOS;

namespace Application.Books.DTOS
{
    public class GetBookPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public int BookID { get; set; }
    }
}