using Library.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IEditorialsRepository
    {
        public Task<IEnumerable<Editorials>> GetEditorials();
        public Task<Editorials> GetEditorial(int id);
        public Task InsertEditorial(Editorials editorial);
        public Task<bool> UpdateEditorial(Editorials editorial);
        public Task<bool> DeleteEditorial(int id);
    }
}
