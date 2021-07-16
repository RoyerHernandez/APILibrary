using Library.Api.Response;
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
        private IAuthorServices _authorService;
        public AuthorsController(IAuthorServices authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _authorService.GetAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var author = await _authorService.GetAuthor(id);
            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> InsertAuthor(Authors author)
        {
            await _authorService.InsertAuthor(author);
            return Ok(author);
        }

        [HttpPut]
        public async Task<IActionResult> putAuthor(int id, Authors author)
        {
            author.Id = id;
            var result = await _authorService.UpdateAuthor(author);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var result = await _authorService.DeleteAuthor(id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }
    }
}
