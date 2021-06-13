using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorsRepository
    {
        private readonly LibraryContext _dbContext;
        public AuthorRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Authors>> GetAuthors()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return authors;
        }
        public async Task<Authors> GetAuthor(int id)
        {
            var author = await _dbContext.Authors.FirstOrDefaultAsync(x => x.Id == id);
            return author;
        }
        public async Task InsertAuthor(Authors author)
        {
            _dbContext.Add(author);
            await _dbContext.SaveChangesAsync();
        }
    }
}
