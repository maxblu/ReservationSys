using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Repositories;


namespace ReservationSys.Domain.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;
        public UnitOfWork(EFDbContext context)
        {
            _context = context;
            ContactRepo = new ContactRepository(_context);
            ReservRepo = new ReservationRepository(_context);
        }
        public ContactRepository ContactRepo { get; private set; }
        public ReservationRepository ReservRepo { get; private set; }

        public EFDbContext ctx => _context;

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}