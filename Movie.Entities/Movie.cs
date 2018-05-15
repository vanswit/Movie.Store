using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Store.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }

        public Movie()
        {

        }
    }
}