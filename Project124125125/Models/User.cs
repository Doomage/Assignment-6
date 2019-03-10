using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project124125125.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Username Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Required !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage ="Role Required !")]
         public Roles Role { get; set; }

        public bool Accepted { get; set; }

        public IEnumerable<Document> Documents { get; set; }

        public User()
        {
            Accepted = false;
        }
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