using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IAuthorsRepository
    {
        public Task<IEnumerable<Authors>> GetAuthors();

        public Task<Authors> GetAuthor(int id);
    }
}
