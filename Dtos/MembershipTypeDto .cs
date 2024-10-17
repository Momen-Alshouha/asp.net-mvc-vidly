using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp.net_vidly.Dtos
{
    public class MembershipTypeDto
    {
        public int MembershipTypeId { get; set; }

        [Required]
        public string Type { get; set; }

        public decimal SignUpFee { get; set; }

        public int DiscountPercentage { get; set; }
    }
}