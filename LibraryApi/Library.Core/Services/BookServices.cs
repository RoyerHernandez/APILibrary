using Library.Core.Entities;
using Library.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBooksRepository _bookRepository;

        public BookServices(IBooksRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Books> GetBook(int id)
        {
            return await _bookRepository.GetBook(id);
        }
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _bookRepository.GetBooks();
        }
        public async Task InsertBook(Books book)
        {
            await _bookRepository.InsertBook(book);
        }
        public async Task<bool> updateBook(Books book)
        {
            return await _bookRepository.updateBook(book);
        }
        public async Task<bool> deleteBook(int id)
        {
            return await _bookRepository.deleteBook(id);
        }
    }
}
