using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<Author>> GetAllWithBooksAsync();

        Task<Author> GetWithBooksByIdAsync(int id);
    }
}