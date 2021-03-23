using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Books.DTOS;
using Application.DTOS;

namespace Application.Books
{
    public interface IManageBookService
    {
        Task<int> Create(BookCreateRequest request);
        Task<int>  Update(BookEditRequest request);
        Task<int>  Delete(int bookID);
        Task<List<BookViewModel>> GetAll();
        Task<PageViewModel<BookViewModel>> GetAllPaging(GetBookPagingRequest request);
    }
}