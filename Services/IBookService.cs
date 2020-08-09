using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;

namespace BookStore.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllWithAuthor();

        Task<Book> GetBookById(int id);

        Task<Book> GetBookByIdWithAuthor(int id);

        Task<IEnumerable<Book>> GetBooksByAuthorId(int authorId);

        Task<Book> CreateBook(Book book);

        Task UpdateBook(Book bookToBeUpdated, Book book);
        
        Task DeleteBook(Book book);
    }
}