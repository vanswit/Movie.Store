using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Review
    {
        public int ID { get; set; }
        [DisplayName("Comment")]
        public string Body { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Rating is required")]
        [Range(1,10,ErrorMessage = "Rating must be between 1 and 10")]
        public int Rating { get; set; }
        public int  MovieID { get; set; }
    }
}
