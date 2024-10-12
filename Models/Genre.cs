using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace asp.net_vidly.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }

        // Navigation property (optional) if we want to access movies related to this genre
        public ICollection<Movie> Movies { get; set; }
    }
}