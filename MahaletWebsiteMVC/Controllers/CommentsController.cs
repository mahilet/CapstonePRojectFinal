using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JeffriesDataLibrary;

namespace MahaletWebsiteMVC.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        public ActionResult Index()
        {
            CommentsService service = new CommentsService();
            List<Comment> comments = service.GetAll();
            return View(comments);
        }

        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {
            CommentsService service = new CommentsService();
            Comment comment = service.Get(id);
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CommentsService service = new CommentsService();

                Comment comment = new Comment()
                {
                    CourseId = Convert.ToInt32(collection["CourseId"]),
                    Text = collection["Text"],
                    Name = collection["Name"],
                    DatePosted = Convert.ToDateTime(collection["DatePosted"])

                };

                Comment newComment = service.Add(comment);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int id)
        {
            CommentsService service = new CommentsService();
            Comment comment = service.Get(id);
            return View(comment);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                CommentsService service = new CommentsService();

                Comment comment = new Comment()
                {
                    CommentId = Convert.ToInt32(collection["CommentId"]),
                    CourseId = Convert.ToInt32(collection["CourseId"]),
                    Text = collection["Text"],
                    Name = collection["Name"],
                    DatePosted = Convert.ToDateTime(collection["DatePosted"])
                };

                bool succeeded = service.Update(comment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {
            CommentsService service = new CommentsService();
            Comment comment = service.Get(id);

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                CommentsService service = new CommentsService();
                service.Remove(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
