using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly IRepository<Books> _bookRepository;
        private readonly IRepository<Editorials> _editorialsRepository;

        public BookServices(IRepository<Books> bookRepository, IRepository<Editorials> editorialsRepository)
        {
            _bookRepository = bookRepository;
            _editorialsRepository = editorialsRepository;
        }

        public async Task<Books> GetBook(int id)
        {
            return await _bookRepository.GetById(id);
        }
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _bookRepository.GetAll();
        }
        public async Task InsertBook(Books book)
        {
            var editorial = await _editorialsRepository.GetById(book.EditorialId);

            if (editorial == null)
            {
                throw new Exception("The editorial doesn't exist");
            }

            if (book.Pages.Length < 2)
            {
                throw new Exception("The number page of th book is not allowed");
            }

            await _bookRepository.Add(book);
        }
        public async Task<bool> updateBook(Books book)
        {
            await _bookRepository.Update(book);
            return true;
        }
        public async Task<bool> deleteBook(int id)
        {
            await _bookRepository.Delete(id);
            return true;
        }
    }
}
