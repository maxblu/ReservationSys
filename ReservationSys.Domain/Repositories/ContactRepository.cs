



using System.Collections.Generic;
using System.Threading.Tasks;
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

        public override async Task<IEnumerable<Contact>> GetAll()
        {
            return await _table.Include("Type").ToListAsync();
        }

        public override async Task<Contact> GetById(int id)
        {
            //Hacer .result para recuperar
            return await _table.Include("Type").FirstOrDefaultAsync(x => x.Id == id);
        }












    }




}