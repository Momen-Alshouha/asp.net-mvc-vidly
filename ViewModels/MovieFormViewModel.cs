using asp.net_vidly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}