using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Entities;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Author> CreateAuthor(Author author)
        {
            await _unitOfWork.Authors
                .AddAsync(author);

            await _unitOfWork.CommitAsync();

            return author;
        }

        public async Task DeleteAuthor(Author author)
        {
            _unitOfWork.Authors.Remove(author);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await _unitOfWork.Authors.GetAllAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task UpdateAuthor(Author authorToBeUpdated, Author author)
        {
            authorToBeUpdated.FirstName = author.FirstName;
            authorToBeUpdated.LastName = author.LastName;

            await _unitOfWork.CommitAsync();
        }
    }
}