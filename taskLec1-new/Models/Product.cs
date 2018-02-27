using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace taskLec1_new.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public decimal salary { get; set; }
        public int quantity { get; set; }
        public DateTime DateAdd { get; set; }
        public string Description { get; set; }
    }
}