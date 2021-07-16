using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IBookServices
    {
        public Task<IEnumerable<Books>> GetBooks();
        public Task<Books> GetBook(int id);
        public Task InsertBook(Books book);
        public Task<bool> updateBook(Books book);
        public Task<bool> deleteBook(int id);
    }
}