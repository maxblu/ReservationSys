



using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Repositories
{

    public class ContactRepository : GenericRepository<Contact>
    {
        protected readonly DbSet<Contact> _table;
        public ContactRepository(EFDbContext context) : base(context)
        {
            _table = _context.Set<Contact>();
        }

        public override IEnumerable<Contact> GetAll()
        {
            return _table.Include("Type");
        }

        public override Contact GetById(int id)
        {
            return _table.Include("Type").FirstOrDefaultAsync(x => x.Id == id).Result;
        }












    }




}