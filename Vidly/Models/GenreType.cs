﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenreType
    {
        public byte Id { get; set; }
        [Required]
        public string name { get; set; }
    }
}