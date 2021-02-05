using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    EFDbContext ctx { get; }
    ContactRepository ContactRepo { get; }
    ReservationRepository ReservRepo { get; }
    Task<int> Complete();
}