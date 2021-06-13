using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return Ok(editorials);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEditorial(int id)
        {
            var editorial = await _editorialRepository.GetEditorial(id);
            return Ok(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> InsertEditoria(Editorials editorial)
        {
            await _editorialRepository.InsertEditorial(editorial);
            return Ok(editorial);
        }
    }
}
