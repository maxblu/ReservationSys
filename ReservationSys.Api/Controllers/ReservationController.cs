using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;
using ReservationSys.Domain.UnitOfWork;

namespace ReservationSys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReservationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservation = await _unitOfWork.ReservRepo.GetAll();

            if (reservation == null)
            {
                return NotFound();
            }


            return Ok(reservation);
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _unitOfWork.ReservRepo.GetById(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/Reservation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.ReservRepo.Add(reservation);

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

        // POST: api/Reservation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            if (ModelState.IsValid)
            {

                await _unitOfWork.ReservRepo.Add(reservation);


                await _unitOfWork.Complete();

                return CreatedAtAction("GetContact", new { id = reservation.Id }, reservation);


            }


            return ValidationProblem(ModelState);
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _unitOfWork.ReservRepo.GetById(id);
            if (reservation == null)
            {
                return NotFound();
            }

            _unitOfWork.ReservRepo.Remove(reservation);
            await _unitOfWork.Complete();

            return NoContent();
        }

        // private bool ReservationExists(int id)
        // {
        //     return _context.Reservations.Any(e => e.Id == id);
        // }
    }
}
