using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorsRepository
    {
        public Task<IEnumerable<Authors>> GetAuthors();
        public Task<Authors> GetAuthor(int id);
        public Task InsertAuthor(Authors author);
        public Task<bool> UpdateAuthor(Authors author);
        public Task<bool> DeleteAuthor(int Id);
    }
}
