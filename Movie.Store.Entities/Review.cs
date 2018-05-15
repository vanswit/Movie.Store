using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Review
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
        public int  MovieID { get; set; }
    }
}
