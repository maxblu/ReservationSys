using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSys.Domain.Entities
{
    public class Reservation
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a reservation title")]
        public string Title { get; set; }

        [Range(0, 5, ErrorMessage = "Please enter a valid ranking (0-5)")]
        public byte Ranking { get; set; }

        public bool IsFavorite { get; set; }

        [DataType(DataType.MultilineText)]

        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Please specify a Contact")]
        [ForeignKey("ContactId")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public DateTime CreationDate { get; set; }
    }

}