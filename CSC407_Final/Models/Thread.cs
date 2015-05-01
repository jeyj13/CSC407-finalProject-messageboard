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
        [Display(Name="Date")]
        public DateTime postDate { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Title")]
        public string title { get; set; }
        [Display(Name = "Body")]
        public string postText { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }
    }
}