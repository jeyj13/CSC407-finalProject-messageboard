using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC407_Final.ViewModels
{
    public class CommentViewModel
    {
        public List<Comment> Comments {get; set;}
        public Thread Thread { get; set; }
        public Comment Comment { get; set; }

    }
}