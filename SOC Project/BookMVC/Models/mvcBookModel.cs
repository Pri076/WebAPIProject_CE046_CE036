using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMVC.Models
{
    public class mvcBookModel
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
    }
}