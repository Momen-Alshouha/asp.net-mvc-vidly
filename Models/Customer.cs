using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_vidly.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        // Foreign Key for MembershipType
        public int MembershipTypeId { get; set; }

        // Navigation Property
        public MembershipType MembershipType { get; set; }
    }
}