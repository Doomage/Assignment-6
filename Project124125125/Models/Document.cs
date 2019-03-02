using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project124125125.Models
{
    public class Document
    {
        
        public int Id { get; set; }
        [Required]
        [Display(Name ="Text Title")]
        public string Name { get;set;}
        [Required]
        public string Text { get; set; }

        [Display(Name = "Role Working Document")]
        public Roles Role { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public User User { get; set; }
    }
}