using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRegistrationDB.Models
{
    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Romance,
        Thriller,
        Western
    }
    public class Movie
    {
        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage = "Title cannot be longer than 30 characters!")]
        public string Title { get; set; }
        public Genre Genre { get; set; }
        [Range(1880,2021,ErrorMessage ="Year must be between 1880 and 2021")]
        public int releaseYear { get; set; }
        public int Runtime { get; set; }
    }
}
