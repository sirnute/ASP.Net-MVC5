using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Name { get; set; }

        [Display(Name ="Genre")]
        public GenreType GenreType { get; set; }

        [Display(Name = "Release Date")]
        [Column(TypeName = "Date")]
        public DateTime ReleasedDate { get; set; }

        [Display(Name = "Date Added")]
        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")] 
        public int NumberInStock { get; set; }

        public byte GenreTypeId { get; set; }
    }
}