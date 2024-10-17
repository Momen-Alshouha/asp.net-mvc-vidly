using asp.net_vidly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace asp.net_vidly.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Min18YearsIfAMember(ErrorMessage = "Customer must be at least 18 years old.")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Required]
        public int MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }

    }
}