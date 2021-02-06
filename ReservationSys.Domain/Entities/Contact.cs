using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;


namespace ReservationSys.Domain.Entities
{
    public class Contact
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a contact name")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Please enter a valid phone")]
        public string Phone { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Please enter a ContactType")]
        public int TypeId { get; set; }

        public ContactType Type { get; set; }

        [Required(ErrorMessage = "Please enter a birthdate")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Must enter id number")]
        public long IdNumber { get; set; }

    }

}