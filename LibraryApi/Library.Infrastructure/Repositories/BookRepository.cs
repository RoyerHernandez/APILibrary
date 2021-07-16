using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBooksRepository
    {
        private readonly LibraryContext _dbContext;
        public BookRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Books>> GetBooks()
        {
            var books = await _dbContext.Books.ToListAsync();
            return books;
        }
        public async Task<Books> GetBook(int id)
        {
            var book = await _dbContext.Books.FirstOrDefaultAsync(x => x.Isbn == id);
            return book;
        }
        public async Task InsertBook(Books book)
        {
            _dbContext.Add(book);
            await _dbContext.SaveChangesAsync();
        }
        //public async Task<IEnumerable<Book>> GetBook()
        //{
        //    var book = Enumerable.Range(1, 10).Select(x => new Book
        //    {
        //        ISBN = x,
        //        editorialId = 1,
        //        sinopsis = $"Sinopcsis nueva{x}",
        //        pages = "500"
        //    }) ;
        //    await Task.Delay(10);
        //    return book;
        //}

        public async Task<bool> updateBook(Books book)
        {
            var currentBook = await GetBook(book.Isbn);
            currentBook.Title = book.Title;
            currentBook.Sinopsis = book.Sinopsis;
            currentBook.Pages = book.Pages;

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> deleteBook(int id)
        {
            var currentBook = await GetBook(id);
            _dbContext.Books.Remove(currentBook);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
