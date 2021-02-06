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
            await _context.Set<TEntity>().AddRangeAsync(entities);

            return entities;
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().AsQueryable().Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int id)
        {

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;

        }
    }

}
