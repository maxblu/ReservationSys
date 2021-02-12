using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Repositories;


/*
the repository pattern is mixed with unitOfWork for better control over 
multiple repositories usnig the same contact and calling save here. in the complete method

*/

public interface IUnitOfWork : IDisposable
{
    EFDbContext ctx { get; }
    ContactRepository ContactRepo { get; }
    ReservationRepository ReservRepo { get; }
    Task<int> Complete();
}