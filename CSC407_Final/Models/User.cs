using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CSC407_Final.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        
        public string Password { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email address is not valid")]
        public string Email { get; set; }
        public bool Admin { get; set; }

    }
}