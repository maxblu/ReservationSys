using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace ReservationSys.Domain.Entities
{
    public class ContactType
    {
        // [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a contact type")]
        public string Name { get; set; }

    }

}