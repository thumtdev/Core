using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books.DTOS;
using Application.DTOS;

namespace Application.Books
{
    public interface IPublicBookService
    {
        Task<PageViewModel<BookViewModel>> GetAllBookByID(GetBookPagingRequest request);
        Task<List<BookViewModel>> GetAll();
        Task<int>  Update(BookEditRequest request);
        Task<int> Create(BookCreateRequest request);
    }
}