using Library.Api.Response;
using Library.Core.DTOs;
using Library.Core.Entities;
using Library.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialsController : ControllerBase
    {
        private IEditorialsRepository _editorialRepository;
        public EditorialsController(IEditorialsRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEditorials()
        {
            var editorials = await _editorialRepository.GetEditorials();
            var editorialsDto = editorials.Select(x => new EditorialDto
            {
                Id = x.Id,
                EditorialName = x.EditorialName,
                Headquarters = x.Headquarters
            });
            return Ok(editorialsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorial(int id)
        {
            var editorial = await _editorialRepository.GetEditorial(id);
            var editorialDto = new EditorialDto
            {
                Id = editorial.Id,
                EditorialName = editorial.EditorialName,
                Headquarters = editorial.Headquarters
            };
            return Ok(editorialDto);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditoria(Editorials editorialDto)
        {
            var editorial = new Editorials
            {
                EditorialName = editorialDto.EditorialName,
                Headquarters = editorialDto.Headquarters
            };
            await _editorialRepository.InsertEditorial(editorial);
            return Ok(editorial);
        }
        [HttpPut]
        public async Task<IActionResult> PutEditorial(int id,Editorials editorial)
        {
            editorial.Id = id;
            var result = await _editorialRepository.UpdateEditorial(editorial);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            var result = await _editorialRepository.DeleteEditorial(id);
            var response = new APIResponse<bool>(result);
            return Ok(response);
        }
    }
}
