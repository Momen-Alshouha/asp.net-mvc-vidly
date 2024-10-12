using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_vidly.Models
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }
        public string Type { get; set; }
        public decimal SignUpFee { get; set; }
        public int DiscountPercentage { get; set; }

        // Navigation property to represent the one-to-many relationship
        public ICollection<Customer> Customers { get; set; }
    }
}