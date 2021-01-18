using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MovieGenreViewModel
    {
        public IEnumerable<Genre> GenreType { get; set; }
        public Movie movie { get; set; }

    }
}