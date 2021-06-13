using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBooksRepository
    {
        public Task<IEnumerable<Books>> GetBooks();
        public Task<Books> GetBook(int id);
    }
}
