using Library.Core.Entities;
using Library.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepositoryMongo : IBooksRepository
    {
        public Task<Books> GetBook(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Books>> GetBooks()
            {
            var book = Enumerable.Range(1, 10).Select(x => new Book
            {
                ISBN = x,
                editorialId = 1,
                sinopsis = $"Sinopsis Mongo{x}",
                pages = "500"
            });
            await Task.Delay(10);
            return (IEnumerable<Books>)book;
        }

        public Task InsertBook(Books book)
        {
            throw new System.NotImplementedException();
        }
    }
}
