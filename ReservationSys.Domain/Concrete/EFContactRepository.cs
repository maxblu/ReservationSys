using System.Collections.Generic;
using ReservationSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ReservationSys.Domain.Concrete
{
    public class EFContactRepository : GenericRepository<Contact, int>
    {
        public EFContactRepository(EFDbContext context) : base(context)
        {

        }

        public override IQueryable<Contact> GetEntities
        {
            get
            {
                return _table.Include("Type");
            }
        }

        public override Contact GetById(int id)
        {
            return _table.Include("Type").FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
