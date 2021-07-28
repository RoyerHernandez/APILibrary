using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Interfaces
{
    public interface IRepository<T> where T: BaseEntity 
    {
        public Task<IEnumerable<T>> GetAll();
        public Task <T> GetById(int id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}
