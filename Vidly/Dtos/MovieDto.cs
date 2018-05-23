using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a valid movie Title")]
        public string Name { get; set; }


        [Column(TypeName = "Date")]
        [Required]
        public DateTime ReleasedDate { get; set; }

        
        [Column(TypeName = "Date")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public byte GenreTypeId { get; set; }

        public GenreTypeDto GenreType { get; set; }
    }
}