using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Abstract
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        IQueryable<TEntity> GetEntities { get; }
        TEntity GetById(TKey id);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TKey id);
        void Save();
    }
}
