using asp.net_vidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}