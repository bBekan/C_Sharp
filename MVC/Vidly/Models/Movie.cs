﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre? Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Date added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [DefaultValue(1)]
        public byte NumberInStock { get; set; }

        [Display(Name = "Number available")]
        public byte NumberAvailable { get; set; }

        public string GetDateAdded()
        {
            return DateAdded.ToShortDateString();
        }

        public string GetReleaseDate()
        {
            return ReleaseDate.ToShortDateString();
        }
    }
}
