using Microsoft.EntityFrameworkCore;
using Pustok.Core.Entites.Common;
using Pustok.DataAccess.Context;
using Pustok.DataAccess.Repositories.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pustok.DataAccess.Repositories.Implementations.Generic
{
    internal class Repository<T>(AppDbContext _context) : IRepository<T> where T : BaseEntity
    {
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
           return  _context.Set<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
           var entity  = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public async Task<T?> GetAsync(Expression<Func<T,bool>> expression)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(expression);
            return entity;
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            var entity = await _context.Set<T>().AnyAsync(expression);
            return entity;
        }
    }
}
