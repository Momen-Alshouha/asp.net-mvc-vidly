using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp.net_vidly.Models;

namespace asp.net_vidly.ViewModels
{
    public class MovieDirectorViewModel
    {
        public Movie Movie{ get; set; }
        public Director Director { get; set; }
        public string DirectorBio { get; set; }

    }
}