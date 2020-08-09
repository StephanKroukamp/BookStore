using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithAuthorAsync();

        Task<Book> GetByIdWithAuthorAsync(int id);

        Task<IEnumerable<Book>> GetAllWithAuthorByAuthorIdAsync(int authorId);
    }
}