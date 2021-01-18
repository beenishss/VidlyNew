using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public DateTime? ReleaseDate { get; set; }
        public byte GenreId { get; set; }
        public Genre GenreType { get; set; }
    }
}