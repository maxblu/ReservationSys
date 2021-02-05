using System.Collections.Generic;
using System.Linq;
using ReservationSys.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using System.Linq.Expressions;
using System;

namespace ReservationSys.Domain.Repositories
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly EFDbContext _context;

        public GenericRepository(EFDbContext context)
        {
            _context = context;

        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }
    }

}
