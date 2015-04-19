using CSC407_Final.Data;
using CSC407_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC407_Final.Services.Posting
{
    public class PostServices : IPostServices
    {
        private FinalDbContext context;

 //*****************************************************************************************************************       
            public PostServices()
            {
                this.context = new FinalDbContext();
            }
        //**********************************************************************************************************
        public List<Thread> GetThreads()
            {
                var Threads = this.context.Threads.ToList();

                return this.context.Threads.ToList();
            }
        //**********************************************************************************************************
        public Thread GetThreadById(int id)
        {

            return this.context.Threads.Where(x => x.threadId == id).SingleOrDefault();

        }
        //***********************************************************************************************************
        public void SaveThread(Thread thread)
        {
            this.context.Threads.Add(thread);

            this.context.SaveChanges();
        }
        //***********************************************************************************************************
        public void DeleteThread(int id)
        {
            var thread = this.context.Threads.Where(x => x.threadId == id).SingleOrDefault();

            this.context.Threads.Remove(thread);

            this.context.SaveChanges();
        }
        //***********************************************************************************************************
        public List<Comment> GetComments(int id)
        {
            var Comments = this.context.Comments.ToList().Where(x => x.threadId == id).SingleOrDefault();

            return this.context.Comments.ToList();
        }
        //***********************************************************************************************************
        public void SaveComment(Comment comment)
        {
            this.context.Comments.Add(comment);

            this.context.SaveChanges();
        }
        //***********************************************************************************************************
        public void DeleteComment(int id)
        {
            var comment = this.context.Comments.Where(x => x.commentId == id).SingleOrDefault();

            this.context.Comments.Remove(comment);

            this.context.SaveChanges();
        }
    }
}