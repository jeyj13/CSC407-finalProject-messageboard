using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSC407_Final.Models
{
    public class Thread
    {

        [Key]
        public int threadId { get; set; }

        public DateTime postDate { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public string postText { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}