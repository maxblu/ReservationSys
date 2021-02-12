using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservationSys.Domain.Repositories;
using ReservationSys.Domain.Concrete;
using System;
using System.Linq;
using ReservationSys.Domain.Entities;
using System.Collections.Generic;

namespace ReservationSys.Api.Initializers
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EFDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EFDbContext>>()))
            {

                //Dev only
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var types = new List<ContactType>
            {
                new ContactType{
                Name = "Unknown"
                },
                new ContactType{
                Name = "Important"
                },
                new ContactType{
                Name = "Work"
                },
                new ContactType{
                Name = "Family"
                }
            };
                // Look for any 
                if (context.Contacts.Any())
                {
                    return;
                }

                types.ForEach(t => context.ContactTypes.Add(t));
                context.SaveChanges();

                var contacts = new List<Contact>
            {
                new Contact{
                    Name = "Person1",
                    BirthDate = new DateTime(2000, 5, 1),
                    TypeId = 2,
                    Phone = "01010101"
                },
                new Contact{
                    Name = "Person2",
                    BirthDate = new DateTime(1908, 5, 19),
                    TypeId = 2,
                    Phone = "81281281"
                },
                new Contact{
                    Name = "Person3",
                    BirthDate = new DateTime(1924, 10, 12),
                    TypeId = 3,
                    Phone = "35467891"
                },
                new Contact{
                    Name = "Person4",
                    BirthDate = new DateTime(1982, 8, 10),
                    TypeId = 4,
                    Phone = "88888888"
                },
                new Contact{
                    Name = "Person5",
                    BirthDate = new DateTime(1999, 2, 28),
                    TypeId = 1,
                    Phone = "00000000"
                },
                new Contact{
                    Name = "Person6",
                    BirthDate = new DateTime(1961, 3, 22),
                    TypeId = 2,

                    Phone = "74289567"
                },
            };

                contacts.ForEach(t => context.Contacts.Add(t));
                context.SaveChanges();

                var reservations = new List<Reservation>
            {
                new Reservation{
                    Title = "Reservation1",
                    Date = new DateTime(2022, 3, 11),
                    ContactId = 1,
                    Description = "Hello",
                    IsFavorite = true,
                    Ranking = 5,
                    CreationDate= new DateTime(2021,5,30)
                },
                new Reservation{
                    Title = "Reservation2",
                    Date = new DateTime(2022, 2, 10),
                    ContactId = 3,
                    Description =  "Hello",
                    IsFavorite = false,
                    Ranking = 2,
                    CreationDate= new DateTime(2021,5,30)
                },
                new Reservation{
                    Title = "Reservation3",
                    Date = new DateTime(2022, 11, 8),
                    ContactId = 4,
                    IsFavorite = false,
                    Ranking = 4,
                    CreationDate= new DateTime(2021,5,30)
                },
                new Reservation{
                    Title = "Reservation4",
                    Date = new DateTime(2023, 12, 31),
                    ContactId = 5,
                    IsFavorite = true,
                    Ranking = 4,
                    CreationDate= new DateTime(2022, 12, 31),
                },
                new Reservation{
                    Title = "Reservation5",
                    Date = new DateTime(2023, 12, 31),
                    ContactId = 5,
                    IsFavorite = false,
                    Ranking = 1,
                    CreationDate= new DateTime(2022, 12, 31),
                },
                new Reservation{
                    Title = "Reservation6",
                    Date = new DateTime(2023, 12, 31),
                    ContactId = 5,
                    IsFavorite = true,
                    Ranking = 4,
                    CreationDate= new DateTime(2022, 12, 31),
                },
                new Reservation{
                    Title = "Reservation7",
                    Date = new DateTime(2023, 12, 31),
                    ContactId = 1,
                    IsFavorite = false,
                    Ranking = 4,
                    CreationDate= new DateTime(2022, 12, 31),
                },new Reservation{
                    Title = "Reservation8",
                    Date = new DateTime(2023, 12, 31),
                    ContactId = 2,
                    IsFavorite = false,
                    Ranking = 4,
                    CreationDate= new DateTime(2022, 12, 31),
                },
            };

                reservations.ForEach(t => context.Reservations.Add(t));
                context.SaveChanges();
            }
        }
    }
}