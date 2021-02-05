using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Entities;



namespace ReservationSys.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        // private readonly DbContextOptions _options;
        public EFDbContext(DbContextOptions options) : base(options)
        {
            // _options = options;
        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<ContactType> ContactTypes { get; set; }


    }
}
