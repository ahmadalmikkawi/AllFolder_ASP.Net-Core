using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Store.Modules
{
    public class Book
    {
        [DisplayName("Book Id")]
        public int id { get; set; }

        [DisplayName("Book Title")]
        public string title { get; set; }

        [DisplayName("Book Description")]
        public string descreption { get; set; }

        [DisplayName("Book Author")]
        public Author author { get; set; }

        [DisplayName("Your Image")]
        public string UrlFile { get; set; }
    }
}
