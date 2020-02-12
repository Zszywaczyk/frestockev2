using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StockData.Models
{
    public class Image
    {
        public int id { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "Limit to 60 characters", MinimumLength = 3)]
        public string title { get; set; }
        //public int user_id { get; set; }
        //lub
        public int userid { get; set; } //virtual??
        public int categoryid { get;  set; }
        [Required]
        [StringLength(5, ErrorMessage = "Filetype must be between 3-5", MinimumLength = 3)]
        public string filetype { get; set; }
        [Required]
        [Range(1,6000)]
        public int xsize { get; set; }
        [Required]
        [Range(1, 6000)]
        public int ysize { get; set; }
        [Required]
        public string filename { get; set; }
        public string filepath { get; set; }
        public int Hashtagid { get; set; }
        
        public DateTime DateOfAdd { get; set; }
    }
}
