using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movie.Store.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int MovieId { get; set; }

        public Review()
        {

        }
    }
}