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
        private readonly IUnitOfWork _unitOfWork;
        public EditorialServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Editorials> GetEditorial(int id)
        {
            return await _unitOfWork.EditorialsRepository.GetById(id);
        }
        public async Task<IEnumerable<Editorials>> GetEditorials()
        {
            return await _unitOfWork.EditorialsRepository.GetAll();
        }
        public async Task InsertEditorial(Editorials editorial)
        {
            await _unitOfWork.EditorialsRepository.Add(editorial);
        }
        public async Task<bool> UpdateEditorial(Editorials editorial)
        {
            await _unitOfWork.EditorialsRepository.Update(editorial);
            return true;
        }
        public async Task<bool> DeleteEditorial(int id)
        {
            await _unitOfWork.EditorialsRepository.Delete(id);
            return true;
        }
    }
}
