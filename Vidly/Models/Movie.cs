using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public GenreType GenreType { get; set; }
        [Column(TypeName = "Date")]
        public DateTime ReleasedDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
    }
}