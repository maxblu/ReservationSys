



using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Domain.Repositories
{

    public class ReservationRepository : GenericRepository<Reservation>
    {

        public ReservationRepository(EFDbContext context) : base(context)
        {

        }

        // public override async Task<IEnumerable<Reservation>> GetAll()
        // {
        //     return await _table.Include("Contact").ToListAsync();
        // }


        public override async Task<Reservation> GetById(int id)
        {
            return await _table.Include("Contact").FirstOrDefaultAsync(x => x.Id == id);
        }

    }




}