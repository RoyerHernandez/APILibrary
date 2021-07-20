using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBooksRepository _bookRepository;
        private readonly IEditorialsRepository _editorialsRepository;

        public BookServices(IBooksRepository bookRepository, IEditorialsRepository editorialsRepository)
        {
            _bookRepository = bookRepository;
            _editorialsRepository = editorialsRepository;
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
            var editorial = await _editorialsRepository.GetEditorial(book.EditorialId);

            if (editorial == null)
            {
                throw new Exception("The editorial doesn't exist");
            }

            if (book.Pages.Length < 2)
            {
                throw new Exception("The number page of th book is not allowed");
            }

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
