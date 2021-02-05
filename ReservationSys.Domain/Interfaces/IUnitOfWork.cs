using System;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Repositories;

public interface IUnitOfWork : IDisposable
{
    EFDbContext ctx { get; }
    ContactRepository ContactRepo { get; }
    ReservationRepository ReservRepo { get; }
    int Complete();
}