using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Entities
{
    public class Movie
    {
        public int ID { get; set; }
        [DisplayName("Title")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Name { get; set; }
        [DisplayName("Release")]
        [Range(1900,3000,ErrorMessage = "Please pick a valid year")]
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
    }
}
