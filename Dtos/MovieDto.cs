using System;
using System.ComponentModel.DataAnnotations;

namespace asp.net_vidly.Dtos
{
    public class MovieDto
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
        public GenreDto Genre { get; set; }
    }

    public class GenreDto
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
