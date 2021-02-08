using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReservationSys.Domain.Concrete;
using ReservationSys.Domain.Entities;
using ReservationSys.Api.Wrappers;
using ReservationSys.Api.Filters;
using ReservationSys.Api.Helpers;
// using ReservationSys.Api.Helpers;

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
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations(string by = "Title", string sortOrder = "dsc", int pageNumber = 1, int pageSize = 3)
        {
            var validPaginationFilter = new PaginationFilter(pageNumber, pageSize);
            IEnumerable<Reservation> reservations;

            int totalRecords = await _unitOfWork.ctx.Reservations.CountAsync();


            if (sortOrder == "asc")
            {
                reservations = await _unitOfWork.ReservRepo.GetAll(
                            paginationFilter: reservation => reservation.Skip(((validPaginationFilter.PageNumber - 1) * validPaginationFilter.PageSize)).
                                                                            Take(validPaginationFilter.PageSize),
                            orderBy: reservation => reservation.OrderBy($"{by}"),
                            includeProperties: "Contact");
            }
            else
            {
                reservations = await _unitOfWork.ReservRepo.GetAll(
                        paginationFilter: reservation => reservation.Skip(((validPaginationFilter.PageNumber - 1) * validPaginationFilter.PageSize)).
                                                                        Take(validPaginationFilter.PageSize),
                        orderBy: reservation => reservation.OrderByDescending($"{by}"),
                        includeProperties: "Contact");
            }

            if (reservations == null)
            {
                return NotFound();
            }



            return Ok(
                new PagedResponse<IEnumerable<Reservation>>
                    (reservations, validPaginationFilter.PageNumber, validPaginationFilter.PageSize)
                {
                    TotalRecords = totalRecords,
                    TotalPages = (int)Math.Ceiling((double)(totalRecords / pageSize))
                });
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

            return Ok(new Response<Reservation>(reservation));
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
                _unitOfWork.ReservRepo.Update(reservation);

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
            System.Console.WriteLine("HEllooooooooo");
            if (ModelState.IsValid)
            {

                await _unitOfWork.ReservRepo.Add(reservation);


                await _unitOfWork.Complete();

                return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);


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
