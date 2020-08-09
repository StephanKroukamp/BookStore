using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDbContext;

        private IAuthorRepository _authorRepository;

        private IBookRepository _bookRepository;

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_applicationDbContext);

        public IBookRepository Books => _bookRepository ??= new BookRepository(_applicationDbContext);

        public async Task<int> CommitAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
        }
    }
}