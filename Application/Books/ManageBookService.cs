using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Books.DTOS;
using Application.DTOS;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using UTILITIES;

namespace Application.Books
{
    public class ManageBookService : IManageBookService
    {
        private readonly BaseContext _context;
        public ManageBookService(BaseContext context)
        {
            _context = context;
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

        public async Task<int> Delete(int bookID)
        {
            var book = await _context.Books.FindAsync(bookID);
            if (book == null) throw new BaseException($"Not found book: {bookID}");
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<BookViewModel>> GetAll()
        {
            var query = await _context.Books.ToListAsync();

            var result = query.Select(b => new BookViewModel()
            {
                    ID = b.ID,
                    Title = b.Title,
                    Author = b.Author,
                    Language = b.Language
            }).ToList();

            return result;
        }

        public async Task<PageViewModel<BookViewModel>> GetAllPaging(GetBookPagingRequest request)
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

        public async Task<int> Update(BookEditRequest request)
        {
            var book = await _context.Books.FindAsync(request.ID);
            if (book == null) throw new BaseException($"Not found book: {request.ID}");
            book.Title = request.Title;
            book.Author = request.Author;
            book.Language = request.Language;
            return await _context.SaveChangesAsync();
        }
    }
}