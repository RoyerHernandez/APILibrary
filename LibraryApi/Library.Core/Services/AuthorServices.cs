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
        private readonly IAuthorsRepository _authorsRepository;
        public AuthorServices(IAuthorsRepository authorsRepository)
        {
            _authorsRepository = authorsRepository;
        }

        public async Task<Authors> GetAuthor(int id)
        {
            return await _authorsRepository.GetAuthor(id);
        }
        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            return await _authorsRepository.GetAuthors();
        }
        public async Task InsertAuthor(Authors author)
        {
            await _authorsRepository.InsertAuthor(author);
        }
        public async Task<bool> UpdateAuthor(Authors author)
        {
            return await _authorsRepository.UpdateAuthor(author);
        }
        public async Task<bool> DeleteAuthor(int Id)
        {
            return await _authorsRepository.DeleteAuthor(Id);
        }
    }
}
