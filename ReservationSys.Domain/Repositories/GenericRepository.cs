using System.Collections.Generic;
using System.Linq;
using ReservationSys.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace ReservationSys.Domain.Repositories
{

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EFDbContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(EFDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();

        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _table.AddAsync(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);

            return entities;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _table.AsQueryable().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _table;


            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }


        }


        public virtual async Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IQueryable<TEntity>> paginationFilter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _table;


            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (paginationFilter != null)
            {
                return await paginationFilter(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }


        }


        public virtual async Task<TEntity> GetById(int id)
        {

            return await _table.FindAsync(id);
        }

        public virtual void Remove(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        public void Update(TEntity obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

        }

    }

}
