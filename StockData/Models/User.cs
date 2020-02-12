using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace StockData.Models
{
    public class User
    {
        public int id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Login must be between 4-20", MinimumLength = 4)]
        public string login { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Password must be between 6-30", MinimumLength = 6)]
        public string password { get; set; }
        public Boolean isActive { get; set; }
        [Required]
        public string email { get; set; }
    }
}
