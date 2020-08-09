using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();

        Task<Author> GetAuthorById(int id);

        Task<Author> CreateAuthor(Author author);

        Task UpdateAuthor(Author authorToBeUpdated, Author author);

        Task DeleteAuthor(Author author);
    }
}