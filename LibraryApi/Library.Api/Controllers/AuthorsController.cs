using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsRepository _authorsRepository;
        public AuthorsController(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorsRepository.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _authorsRepository.GetAuthor(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor(Authors author)
        {
            await _authorsRepository.InsertAuthor(author);
            return Ok(author);
        }
    }
}
