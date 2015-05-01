using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSC407_Final.Models
{
    public class Comment
    {

        [Key]
        public int commentId { get; set; }


        public int? threadId { get; set; }
        //public virtual ICollection<User> user { get; set; }
       // [ForeignKey("username")]
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
        [Display(Name = "Date")]
        public DateTime timestamp { get; set; }

        
                
        [ForeignKey("threadId")]
        public virtual Thread thread { get; set; }
        public virtual ICollection<Thread> threads { get; set; }
        
        
    }
}