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
                // Look for any movies.
                if (context.Contacts.Any())
                {
                    return;   // DB has been seeded
                }

                types.ForEach(t => context.ContactTypes.Add(t));
                context.SaveChanges();

                var contacts = new List<Contact>
            {
                new Contact{
                    Name = "Batman",
                    BirthDate = new DateTime(1939, 5, 1),
                    TypeId = 2,
                    IdNumber=1,
                    Phone = "01010101"
                },
                new Contact{
                    Name = "Superman",
                    BirthDate = new DateTime(1938, 2, 19),
                    TypeId = 2,
                     IdNumber=2,
                    Phone = "81281281"
                },
                new Contact{
                    Name = "Wolverine",
                    BirthDate = new DateTime(1974, 10, 12),
                    TypeId = 3,
                     IdNumber=3,
                    Phone = "35467891"
                },
                new Contact{
                    Name = "Spider-Man",
                    BirthDate = new DateTime(1962, 8, 8),
                    TypeId = 4,
                     IdNumber=4,
                    Phone = "88888888"
                },
                new Contact{
                    Name = "Flash",
                    BirthDate = new DateTime(1959, 12, 28),
                    TypeId = 1,
                    IdNumber=5,
                    Phone = "00000000"
                },
                new Contact{
                    Name = "Wonder Woman",
                    BirthDate = new DateTime(1941, 3, 22),
                    TypeId = 2,
                     IdNumber=6,
                    Phone = "74289567"
                },
            };

                contacts.ForEach(t => context.Contacts.Add(t));
                context.SaveChanges();

                var reservations = new List<Reservation>
            {
                new Reservation{
                    Title = "Save Gotham",
                    Date = new DateTime(1989, 3, 11),
                    ContactId = 1,
                    Description = "Fight Joker",
                    IsFavorite = true,
                    Ranking = 5,
                    CreationDate= new DateTime(1900,5,30)
                },
                new Reservation{
                    Title = "X-Men meeting",
                    Date = new DateTime(1989, 2, 10),
                    ContactId = 3,
                    Description = "Again...",
                    IsFavorite = false,
                    Ranking = 2,
                    CreationDate= new DateTime(1900,5,30)
                },
                new Reservation{
                    Title = "Make a costume",
                    Date = new DateTime(1974, 11, 8),
                    ContactId = 4,
                    IsFavorite = false,
                    Ranking = 4,
                    CreationDate= new DateTime(1900,5,30)
                },
                new Reservation{
                    Title = "Go and Back",
                    Date = new DateTime(1979, 12, 31),
                    ContactId = 5,
                    Description = "Very fast, it didn't move.",
                    IsFavorite = true,
                    Ranking = 4,
                    CreationDate= new DateTime(1900,5,30)
                },
            };

                reservations.ForEach(t => context.Reservations.Add(t));
                context.SaveChanges();
            }
        }
    }
}