using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            var contacs = await _unitOfWork.ContactRepo.GetAll();

            if (contacs == null)
            {
                return NotFound();
            }


            return Ok(contacs);

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
            if (ModelState.IsValid)
            {

                await _unitOfWork.ContactRepo.Add(contact);


                await _unitOfWork.Complete();

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


    }
}
