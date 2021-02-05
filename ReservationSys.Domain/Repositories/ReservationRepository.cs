



using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Repositories
{

    public class ReservationRepository : GenericRepository<Contact>
    {
        protected readonly DbSet<Contact> _table;
        public ReservationRepository(EFDbContext context) : base(context)
        {
            _table = _context.Set<Contact>();
        }

        public override IEnumerable<Contact> GetAll()
        {
            return _table.Include("Contact");
        }

        public override Contact GetById(int id)
        {
            return _table.Include("Contact").FirstOrDefaultAsync(x => x.Id == id).Result;
        }












    }




}