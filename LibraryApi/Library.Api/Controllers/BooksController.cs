using Library.Api.Response;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookServices _bookService;
        public BooksController(IBookServices bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(Books book)
        {
            await _bookService.InsertBook(book);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> putBook(int id, Books book)
        {
            book.Isbn = id;
            var result = await _bookService.updateBook(book);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            var result = await _bookService.deleteBook(id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }
    }
}
