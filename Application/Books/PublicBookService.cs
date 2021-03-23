using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Books.DTOS;
using Application.DTOS;
using Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Application.Books
{
    public class PublicBookService : IPublicBookService
    {
        private readonly BaseContext _context;
        public PublicBookService(BaseContext context)
        {
            _context = context;
        }

        public async Task<List<BookViewModel>> GetAll()
        {
            var query = _context.Books;

            var result = await query.Select(b => new BookViewModel()
            {
                ID = b.ID,
                Title = b.Title,
                Author = b.Author,
                Language = b.Language
            }).ToListAsync();

            return result;
        }

        public async Task<PageViewModel<BookViewModel>> GetAllBookByID(GetBookPagingRequest request)
        {
            var query = _context.Books.Where(x => x.Title.Contains(request.Keyword));
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(b => new BookViewModel()
                            {
                                ID = b.ID,
                                Title = b.Title,
                                Author = b.Author
                            }).ToListAsync();
            var pageResult = new PageViewModel<BookViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pageResult;
        }
    
    public async Task<int> Create(BookCreateRequest request)
        {
            var book = new Data.Entities.Book()
            {
                Title = request.Title,
                Author = request.Author,
                Language = request.Language,
                Publisher = new List<Data.Entities.Publisher>()
                {
                    new Data.Entities.Publisher(){
                        Name = request.PublisherName
                    }
                }
            };
            _context.Books.Add(book);
            return await _context.SaveChangesAsync();
        }

        public Task<int> Update(BookEditRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}