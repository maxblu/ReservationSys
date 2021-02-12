using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Entities;


/*
DB Context for the databse entities

*/

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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<Reservation>().ToSqlQuery(
            //     @"
            //         CREATE PROCEDURE [dbo].[res_DeleteReservation]
            //         -- Add the parameters for the stored procedure here
            //         @ReservationId int
            //         AS
            //         BEGIN
            //         -- SET NOCOUNT ON added to prevent extra result sets from
            //         -- interfering with SELECT statements.
            //         SET NOCOUNT ON;

            //         DELETE FROM [dbo].[Reservation]
            //         where Id = @ReservationId

            //         END

            //     "

            // );

            // modelBuilder.Entity<Reservation>().ToFunction("DeleteDirect");




        }
    }
}
