



using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Repositories
{

    public class ContactRepository : GenericRepository<Contact>
    {

        public ContactRepository(EFDbContext context) : base(context)
        {

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