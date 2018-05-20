using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<GenreType> GenreTypes { get; set; }

        public int? ID { get; set; }

        [Required(ErrorMessage = "Please enter a valid movie Title")]
        public string Name { get; set; }

        
        [Display(Name = "Release Date")]
        [Column(TypeName = "Date")]
        [Required]
        public DateTime? ReleasedDate { get; set; }

       
        [Display(Name = "Number in stock")]
        [Required]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreTypeId { get; set; }

        public string Title { get; set; }


        public MovieFormViewModel()
        {
            ID = 0;
        }

        public MovieFormViewModel(Movie Movie)
        {
            ID = Movie.ID;
            Name = Movie.Name;
            ReleasedDate = Movie.ReleasedDate;
            NumberInStock = Movie.NumberInStock;
            GenreTypeId = Movie.GenreTypeId;
        }
    }
}