using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSC407_Final.Controllers
{
    public class ThreadController : Controller
    {
        // GET: Thread
        public ActionResult ThreadList()
        {
            return View();
        }

        // GET: Thread/Details/5
        public ActionResult ViewThread(int id)
        {
            return View();
        }

        // GET: Thread/Create
        public ActionResult CreateThread()
        {
            return View();
        }

        // POST: Thread/Create
        [HttpPost]
        public ActionResult CreateThread(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Edit/5
        public ActionResult EditThread(int id)
        {
            return View();
        }

        // POST: Thread/Edit/5
        [HttpPost]
        public ActionResult EditThread(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Thread/Delete/5
        public ActionResult DeleteThread(int id)
        {
            return View();
        }

        // POST: Thread/Delete/5
        [HttpPost]
        public ActionResult DeleteThread(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
