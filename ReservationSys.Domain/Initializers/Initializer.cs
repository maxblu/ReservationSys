// using System;
// using System.Collections.Generic;
// using ReservationSys.Domain.Entities;
// using ReservationSys.Domain.Concrete;
// using Microsoft.EntityFrameworkCore;

// namespace ReservationSys.Domain.Initializers
// {
//     public class Initializer : DropCreateDatabaseAlways<EFDbContext>
//     {
//         protected override void Seed(EFDbContext ctx)
//         {
//             var types = new List<ContactType>
//             {
//                 new ContactType{
//                 Name = "Unknown"
//                 },
//                 new ContactType{
//                 Name = "Important"
//                 },
//                 new ContactType{
//                 Name = "Work"
//                 },
//                 new ContactType{
//                 Name = "Family"
//                 }
//             };

//             types.ForEach(t => ctx.ContactTypes.Add(t));
//             ctx.SaveChanges();

//             var contacts = new List<Contact>
//             {
//                 new Contact{
//                     Name = "Batman",
//                     BirthDate = new DateTime(1939, 5, 1),
//                     TypeId = 2,
//                     Description = "Bruce Wayne",
//                     Phone = "01010101"
//                 },
//                 new Contact{
//                     Name = "Superman",
//                     BirthDate = new DateTime(1938, 2, 19),
//                     TypeId = 3,
//                     Description = "Clark Kent",
//                     Phone = "81281281"
//                 },
//                 new Contact{
//                     Name = "Wolverine",
//                     BirthDate = new DateTime(1974, 10, 12),
//                     TypeId = 3,
//                     Description = "Logan (James Howlett)",
//                     Phone = "35467891"
//                 },
//                 new Contact{
//                     Name = "Spider-Man",
//                     BirthDate = new DateTime(1962, 8, 8),
//                     TypeId = 4,
//                     Description = "Peter Parker",
//                     Phone = "88888888"
//                 },
//                 new Contact{
//                     Name = "Flash",
//                     BirthDate = new DateTime(1959, 12, 28),
//                     TypeId = 1,
//                     Description = "Barry Allen",
//                     Phone = "00000000"
//                 },
//                 new Contact{
//                     Name = "Wonder Woman",
//                     BirthDate = new DateTime(1941, 3, 22),
//                     TypeId = 2,
//                     Description = "Diana Prince",
//                     Phone = "74289567"
//                 },
//             };

//             contacts.ForEach(t => ctx.Contacts.Add(t));
//             ctx.SaveChanges();

//             var reservations = new List<Reservation>
//             {
//                 new Reservation{
//                     Name = "Save Gotham",
//                     Date = new DateTime(1989, 3, 11),
//                     ContactId = 1,
//                     Description = "Fight Joker",
//                     IsFavorite = true,
//                     Ranking = 5
//                 },
//                 new Reservation{
//                     Name = "X-Men meeting",
//                     Date = new DateTime(1989, 2, 10),
//                     ContactId = 3,
//                     Description = "Again...",
//                     IsFavorite = false,
//                     Ranking = 2
//                 },
//                 new Reservation{
//                     Name = "Make a costume",
//                     Date = new DateTime(1974, 11, 8),
//                     ContactId = 4,
//                     IsFavorite = false,
//                     Ranking = 4
//                 },
//                 new Reservation{
//                     Name = "Go and Back",
//                     Date = new DateTime(1979, 12, 31),
//                     ContactId = 5,
//                     Description = "Very fast, it didn't move.",
//                     IsFavorite = true,
//                     Ranking = 4
//                 },
//             };

//             reservations.ForEach(t => ctx.Reservations.Add(t));
//             ctx.SaveChanges();
//         }
//     }
// }