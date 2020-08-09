using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        { }
        public async Task<IEnumerable<Author>> GetAllWithBooksAsync()
        {
            return await ApplicationDbContext.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public Task<Author> GetWithBooksByIdAsync(int id)
        {
            return ApplicationDbContext.Authors
                .Include(a => a.Books)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}