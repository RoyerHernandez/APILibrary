using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class BookServices : IBookServices
    {
        private readonly IUnitOfWork _unitOfWork;        

        public BookServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Books> GetBook(int id)
        {
            return await _unitOfWork.BooksRepository.GetById(id);
        }
        public async Task<IEnumerable<Books>> GetBooks()
        {
            return await _unitOfWork.BooksRepository.GetAll();
        }
        public async Task InsertBook(Books book)
        {
            var editorial = await _unitOfWork.EditorialsRepository.GetById(book.EditorialId);

            if (editorial == null)
            {
                throw new Exception("The editorial doesn't exist");
            }

            if (book.Pages.Length < 2)
            {
                throw new Exception("The number page of th book is not allowed");
            }

            await _unitOfWork.BooksRepository.Add(book);
        }
        public async Task<bool> updateBook(Books book)
        {
            await _unitOfWork.BooksRepository.Update(book);
            return true;
        }
        public async Task<bool> deleteBook(int id)
        {
            await _unitOfWork.BooksRepository.Delete(id);
            return true;
        }
    }
}
