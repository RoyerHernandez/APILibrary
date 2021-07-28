using Library.Core.Entities;
using Library.Core.Interfaces;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly LibraryContext _libraryContext;
        private readonly DbSet<T> _entities;
        public BaseRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            _entities = libraryContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _libraryContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _libraryContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
            _libraryContext.SaveChanges();
        }        
    }
}
