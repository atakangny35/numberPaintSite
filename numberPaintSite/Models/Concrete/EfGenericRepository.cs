using Microsoft.EntityFrameworkCore;
using numberPaintSite.Models.EfCore;
using numberPaintSite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Concrete
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly DB context;
        public EfGenericRepository( DB _context)
        {
            this.context = _context;
        }

        public void add(T Entity)
        {
            context.Set<T>().Add(Entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public async Task<List<T>> exp(Expression<Func<T, bool>> filter = null)
        {
            return await (filter == null
                ? context.Set<T>().ToListAsync()
                : context.Set<T>().Where(filter).ToListAsync());
        }

        public async Task<T> Get(int id)
        {
            
            return await context.Set<T>().FindAsync(id);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public bool SaveChange()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
