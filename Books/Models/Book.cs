using Books.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        [Isbn]
        public string Isbn { get; set; }
    }
}
    
