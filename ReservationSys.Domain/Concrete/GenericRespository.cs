using System.Collections.Generic;
using System.Linq;
using ReservationSys.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ReservationSys.Domain.Concrete
{
    public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class
    {
        protected readonly EFDbContext _ctx;
        protected readonly DbSet<TEntity> _table;


        public GenericRepository(EFDbContext context)
        {
            _ctx = context;
            _table = _ctx.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> GetEntities => _table;

        public virtual void Insert(TEntity obj)
        {
            _table.Add(obj);
        }

        public virtual void Delete(TKey id)
        {
            TEntity elem = _table.Find(id);
            _table.Remove(elem);
        }

        public virtual TEntity GetById(TKey id)
        {
            return _table.Find(id);
        }

        public virtual void Save()
        {
            _ctx.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _table.Attach(obj);
            _ctx.Entry(obj).State = EntityState.Modified;
        }
    }
}
