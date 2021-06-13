﻿using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class EditorialRepository : IEditorialsRepository
    {
        private readonly LibraryContext _dbContext;
        public EditorialRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Editorials>> GetEditorials()
        {
            var editorials = await _dbContext.Editorials.ToListAsync();
            return editorials;
        }
        public async Task<Editorials> GetEditorial(int id)
        {
            var editorial = await _dbContext.Editorials.FirstOrDefaultAsync(x => x.Id == id);
            return editorial;
        }
        public async Task InsertEditorial(Editorials editorial)
        {
            _dbContext.Add(editorial);
            await _dbContext.SaveChangesAsync();
        }
    }
}
