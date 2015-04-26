using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC407_Final.ViewModels
{
    public class CommentViewModel
    {
        public IList<Comment> Comments {get; set;}
        public IList<Thread> Threads { get; set; }

    }
}