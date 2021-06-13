using Library.Core.Interfaces;
using Library.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBooksRepository _booksRepository;
        public BookController(IBooksRepository booksRepository)
        {
            _booksRepository =booksRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _booksRepository.GetBooks();
            return Ok(books);
        }
    }
}
