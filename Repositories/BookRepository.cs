using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }

        public async Task<IEnumerable<Book>> GetAllWithAuthorAsync()
        {
            return await ApplicationDbContext.Books
                .Include(m => m.Author)
                .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId)
        {
            return await ApplicationDbContext.Books
                .Include(m => m.Author)
                .Where(m => m.AuthorId == authorId)
                .ToListAsync();
        }

        public async Task<Book> GetByIdWithAuthorAsync(int id)
        {
            return await ApplicationDbContext.Books
                .Include(m => m.Author)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}