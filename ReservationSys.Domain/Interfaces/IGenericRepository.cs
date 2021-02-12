using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Interfaces
{

    /*
    Using respository pattern this is the interface Igeneric
    from this is create a generic repository class that later is 
    extended by other repositories for overriding funtionalities,
    Also we can add to a new repository that is son from genericRepository 
    new methods adding new interfaces for example IcantactRepository
    that way the contactRepository can inplement this adding new fatures.
    */
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity obj);
    }
}
