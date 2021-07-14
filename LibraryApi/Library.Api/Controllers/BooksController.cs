using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBooksRepository _booksRepository;
        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _booksRepository.GetBook(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(Books book)
        {
            await _booksRepository.InsertBook(book);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> putBook(int id, Books book)
        {
            book.Isbn = id;
            await _booksRepository.updateBook(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            var result = await _booksRepository.deleteBook(id);
            return Ok(result);
        }
    }
}
