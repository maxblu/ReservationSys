using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Api.Filters;
using ReservationSys.Api.Wrappers;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;

namespace ReservationSys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> Get(int pageNumber = 1, int pageSize = 4)
        {
            var validPaginationFilter = new PaginationFilter(pageNumber, pageSize);

            int totalRecords = await _unitOfWork.ctx.Contacts.CountAsync();


            //THis os how I send the querys to the methods in a way that when they return anly the result is in memorie
            var contacs = await _unitOfWork.ContactRepo.GetAll(
                paginationFilter: reservation => reservation.Skip(((validPaginationFilter.PageNumber - 1) * validPaginationFilter.PageSize)).
                                                                            Take(validPaginationFilter.PageSize),
                orderBy: contacs => contacs.OrderBy(q => q.Name),
                includeProperties: "Type");



            if (contacs == null)
            {

                return NotFound();
            }

            return Ok(
                new PagedResponse<IEnumerable<Contact>>
                    (contacs, validPaginationFilter.PageNumber, validPaginationFilter.PageSize)
                {
                    TotalRecords = totalRecords,
                    TotalPages = (int)Math.Ceiling((decimal)(totalRecords) / pageSize)
                });

        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _unitOfWork.ContactRepo.GetById(id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [Route("/api/Contact/lookup")]
        [HttpGet]
        public async Task<ActionResult<Contact>> GetContactByName(string name)
        {
            var contact = await _unitOfWork.ContactRepo.Find(c => c.Name == name);

            if (contact == null)
            {
                return NotFound();
            }


            // var contactType = await _unitOfWork.ctx.ContactTypes.FindAsync(contact.FirstOrDefault().TypeId);
            // contact.FirstOrDefault().Type = contactType;
            return Ok(contact);
        }




        // // PUT: api/Contact/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.ContactRepo.Update(contact);

                try
                {
                    await _unitOfWork.Complete();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _unitOfWork.ContactRepo.GetById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }


                return NoContent();

            }
            return ValidationProblem(ModelState);
        }

        // POST: api/Contact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            var exist = await ValidateContactNameUnique(contact.Name);



            if (ModelState.IsValid && !exist)
            {

                try
                {
                    await _unitOfWork.ContactRepo.Add(contact);
                    await _unitOfWork.Complete();

                }
                catch (DbUpdateException)
                {

                    return BadRequest();
                    // throw;
                }



                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);


            }
            return ValidationProblem(ModelState);
        }

        // DELETE: api/Contact/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _unitOfWork.ContactRepo.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

            _unitOfWork.ContactRepo.Remove(contact);
            await _unitOfWork.Complete();

            return NoContent();
        }

        private async Task<bool> ValidateContactNameUnique(string name)
        {

            var exist = await _unitOfWork.ctx.Contacts.AnyAsync(c => c.Name == name);
            if (exist)
            {
                ModelState.AddModelError("name", "Al ready exist a Contact with that name");


            }
            return exist;



        }

    }
}
