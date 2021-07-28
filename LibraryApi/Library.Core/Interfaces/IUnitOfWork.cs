using Library.Core.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Books> BooksRepository { get; }
        IRepository<Editorials> EditorialsRepository { get; }
        IRepository<Authors> AuthorsRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
