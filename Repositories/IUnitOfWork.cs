using System;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }

        IBookRepository Books { get; }

        Task<int> CommitAsync();
    }
}