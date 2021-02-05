using ReservationSys.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ReservationSys.Domain.Concrete
{
    public class EFReservationRepository : GenericRepository<Reservation, int>
    {
        public EFReservationRepository(EFDbContext context) : base(context)
        {
        }

        public override IQueryable<Reservation> GetEntities
        {
            get
            {
                return _table.Include("Contact");
            }
        }

        public override Reservation GetById(int id)
        {
            return _table.Include("Contact").FirstOrDefaultAsync(x => x.Id == id).Result;
        }
    }
}
