using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReservationSys.Domain.Entities;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    public ContactController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult GetContacts()
    {

        return Ok(_unitOfWork.ContactRepo.GetAll());

    }


    [HttpPost]
    public IActionResult AddContact()
    {

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

        types.ForEach(t => _unitOfWork.ctx.ContactTypes.Add(t));

        _unitOfWork.Complete();

        var contacts = new List<Contact>
                {
                    new Contact{
                        Name = "Batman",
                        BirthDate = new DateTime(1939, 5, 1),
                        TypeId = 2,
                        Description = "Bruce Wayne",
                        Phone = "01010101"
                    },
                    new Contact{
                        Name = "Superman",
                        BirthDate = new DateTime(1938, 2, 19),
                        TypeId = 3,
                        Description = "Clark Kent",
                        Phone = "81281281"
                    },
                    new Contact{
                        Name = "Wolverine",
                        BirthDate = new DateTime(1974, 10, 12),
                        TypeId = 3,
                        Description = "Logan (James Howlett)",
                        Phone = "35467891"
                    },
                    new Contact{
                        Name = "Spider-Man",
                        BirthDate = new DateTime(1962, 8, 8),
                        TypeId = 4,
                        Description = "Peter Parker",
                        Phone = "88888888"
                    },
                    new Contact{
                        Name = "Flash",
                        BirthDate = new DateTime(1959, 12, 28),
                        TypeId = 1,
                        Description = "Barry Allen",
                        Phone = "00000000"
                    },
                    new Contact{
                        Name = "Wonder Woman",
                        BirthDate = new DateTime(1941, 3, 22),
                        TypeId = 2,
                        Description = "Diana Prince",
                        Phone = "74289567"
                    },
                };

        contacts.ForEach(t => _unitOfWork.ctx.Contacts.Add(t));
        _unitOfWork.Complete();

        return Ok();
    }
}