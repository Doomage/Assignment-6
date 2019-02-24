using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project124125125.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Username Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required !")]
        public string Password { get; set; }

        [Required(ErrorMessage ="Role Required !")]
         public Roles Role { get; set; }
    }

    public enum Roles
    {
        Architect,
        Analyst,
        Programmer,
        Tester,
    }
}