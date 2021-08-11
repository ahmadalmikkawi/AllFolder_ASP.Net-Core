using Book_Store.Modules;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.ViewModel
{
    public class AddAttributeToBook
    {

        [DisplayName("Book Id")]
        public int id { get; set; }

        [DisplayName("Book Title")]
        [Required(ErrorMessage = "Please Enter Book Title")]
        [StringLength(20,MinimumLength = 5)]
        public string title { get; set; }

        [MinLength(10)]
        [DisplayName("Book Description")]
        [Required(ErrorMessage = "Please Enter Book Description")]
        public string descreption { get; set; }

        [DisplayName("Book Author")]
        //[ForeignKey("authors")]
        public int authorId { get; set; }
        public List<Author> authors { get; set; }

        [DisplayName("Update Image")]
        public IFormFile Files { get; set; }

        [DisplayName("Update Image")]
        public string url { get; set; }
    }
}
