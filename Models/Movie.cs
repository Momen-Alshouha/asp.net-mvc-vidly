using asp.net_vidly.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Director { get; set; }

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
