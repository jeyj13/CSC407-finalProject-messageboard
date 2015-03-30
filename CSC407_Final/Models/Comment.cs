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
        public string username { get; set; }
        public string comment { get; set; }
        public DateTime timestamp { get; set; }

        
                
        [ForeignKey("threadId")]
        public virtual Thread thread { get; set; }
        
    }
}