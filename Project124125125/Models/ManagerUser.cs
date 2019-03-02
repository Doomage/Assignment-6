using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project124125125.Models
{
    public class ManagerUser
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Username Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Role Required !")]
         public Roles Role { get; set; }

    }
    public enum Roles
    {
        Analyst,
        Architect,
        Programmer,
        Tester,
        Manager
    }
}