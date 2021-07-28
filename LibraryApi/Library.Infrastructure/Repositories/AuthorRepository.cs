

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
        //public async Task<Authors> GetAuthorForEditorial(int id)      //{
        //    var editorial = await from a in _dbContext.Authors
        //                          join ahb in _dbContext.AuthorsHasBooks on a.id equals ahb.authoresId
        //                          join b in _dbContext.Books on b.ISBN equals ahb.ISBN
        //                          join e in _dbContext.Editorials on b.editorialId equals e.id
        //                          where e.id == id
        //                          select new authorForEditorial
        //                          {
        //                              a.firstName
        //                          };
        //    return editorial;
        //}
        public async Task <bool>UpdateAuthor(Authors author) 
        {
            var currentAuthor = await GetAuthor(author.Id);
            currentAuthor.FirstName = author.FirstName;
            currentAuthor.LastName = author.LastName;

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            var currentAuthor = await GetAuthor(id);
            _dbContext.Authors.Remove(currentAuthor);

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
