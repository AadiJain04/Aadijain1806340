using System;
using System.ComponentModel.DataAnnotations;

namespace AssessmentQues2.Models
{
    public class Movie
    {
        [Key] 
        public int Mid { get; set; }

        [Required]
        [StringLength(50)]
        public string Moviename { get; set; }
    }
}
