using Library.Core.Entities;
using Library.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Services
{
    public class AuthorServices : IAuthorServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Authors> GetAuthor(int id)
        {
            return await _unitOfWork.AuthorsRepository.GetById(id);
        }
        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            return await _unitOfWork.AuthorsRepository.GetAll();
        }
        public async Task InsertAuthor(Authors author)
        {
            await _unitOfWork.AuthorsRepository.Add(author);
        }
        public async Task<bool> UpdateAuthor(Authors author)
        {
            await _unitOfWork.AuthorsRepository.Update(author);
            return true;
        }
        public async Task<bool> DeleteAuthor(int Id)
        {
            await _unitOfWork.AuthorsRepository.Delete(Id);
            return true;
        }
    }
}
