using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _libraryContext;
        private readonly IRepository<Books> _bookRepository;
        private readonly IRepository<Editorials> _editorialsRepository;
        private readonly IRepository<Authors> _authorsRepository;
        public UnitOfWork(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public IRepository<Books> BooksRepository => _bookRepository ?? new BaseRepository<Books>(_libraryContext);
        public IRepository<Editorials> EditorialsRepository => _editorialsRepository ?? new BaseRepository<Editorials>(_libraryContext);
        public IRepository<Authors> AuthorsRepository => _authorsRepository ?? new BaseRepository<Authors>(_libraryContext);

        public void Dispose()
        {
            if (_libraryContext != null)
            {
                _libraryContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _libraryContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _libraryContext.SaveChangesAsync();
        }
    }
}
