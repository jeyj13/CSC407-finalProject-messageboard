﻿using CSC407_Final.Data;
using CSC407_Final.Models;
using CSC407_Final.Services.Posting;
using CSC407_Final.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC407_Final.Controllers
{
    public class CommentController : Controller
    {
        //public Thread OP;
                private PostServices postService;

        public CommentController()
        {
            this.postService = new PostServices();
    }
        //*************
        // GET: Comment
        public ActionResult Comments(int id)
        {
            
            var OP = new CommentViewModel();
            OP.Thread = this.postService.GetThreadById(id);
            OP.Comments = this.postService.GetComments(id);
          //  return View("_OP", details);
            return View(OP);
        }



        // GET: Comment/Create
        public ActionResult CreateComment(int id)
        {
            
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult CreateComment(FormCollection collection)
        {

            Comment comment = new Comment();
            comment.username = collection["username"];
            comment.comment = collection["comment"];
            comment.threadId = Convert.ToInt32(Request["threadId"]);

            try
            {
                this.postService.SaveComment(comment);

                return RedirectToAction("Thread/ThreadList");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Comment comment)
        {
            try
            {
                this.postService.SaveComment(comment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comment/Delete/5
        public ActionResult DeleteComment(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Comment comment)
        {
            try
            {
                this.postService.DeleteComment(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
