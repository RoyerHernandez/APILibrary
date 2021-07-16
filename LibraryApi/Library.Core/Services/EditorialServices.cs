using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class EditorialServices : IEditorialServices
    {
        private readonly IEditorialsRepository _editorialRepository;
        public EditorialServices(IEditorialsRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        public async Task<Editorials> GetEditorial(int id)
        {
            return await _editorialRepository.GetEditorial(id);
        }
        public async Task<IEnumerable<Editorials>> GetEditorials()
        {
            return await _editorialRepository.GetEditorials();
        }
        public async Task InsertEditorial(Editorials editorial)
        {
            await _editorialRepository.InsertEditorial(editorial);
        }
        public async Task<bool> UpdateEditorial(Editorials editorial)
        {
            return await _editorialRepository.UpdateEditorial(editorial);
        }
        public async Task<bool> DeleteEditorial(int id)
        {
            return await _editorialRepository.DeleteEditorial(id);
        }
    }
}
