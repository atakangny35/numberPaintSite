using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace numberPaintSite.Models.Interfaces
{
   public interface IGenericRepository<T> where T:class,new()
    {
        void add(T Entity);
       Task<T> Get(int id);
       Task <IEnumerable<T>> GetAll();
        void Delete(T entity);
       Task <List<T>> exp(Expression<Func<T, bool>> filter = null);
        bool SaveChange();
            
            

            
    }
}
