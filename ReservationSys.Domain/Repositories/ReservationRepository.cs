



using System.Collections.Generic;
using System.Threading.Tasks;
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

        public override async Task<IEnumerable<Contact>> GetAll()
        {
            return await _table.Include("Contact").ToListAsync();
        }

        public override async Task<Contact> GetById(int id)
        {
            return await _table.Include("Contact").FirstOrDefaultAsync(x => x.Id == id);
        }

    }




}