using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public class Author
    {
        [Required(ErrorMessage = "Your Id !")]
        [DisplayName("Your Id")]
        public int id { get; set; }

        [DisplayName("Your Full Name")]
        [Required(ErrorMessage = "Your Full Name !")]
        public string full_name { get; set; }
    }
}
